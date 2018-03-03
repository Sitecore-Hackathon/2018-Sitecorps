using System.Linq;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using static System.FormattableString;
using Community.Feature.IFTTT.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Community.Feature.IFTTT.Forms.Models;
using Sitecore.Data.Items;
using Sitecore.Configuration;

namespace Community.Feature.IFTTT.Forms.Sitecore_Forms_Custom_Actions
{
    public class SalesForceLeadAction : SubmitActionBase<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogSubmit"/> class.
        /// </summary>
        /// <param name="submitActionData">The submit action data.</param>
        public SalesForceLeadAction(ISubmitActionData submitActionData) : base(submitActionData)

        {

        }

        internal Item AccountItem { get; set; }
        internal Item EventItem { get; set; }

        /// <summary>
        /// Tries to convert the specified <paramref name="value" /> to an instance of the specified target type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="target">The target object.</param>
        /// <returns>
        /// true if <paramref name="value" /> was converted successfully; otherwise, false.
        /// </returns>
        protected override bool TryParse(string value, out string target)
        {
            target = string.Empty;
            return true;
        }

        public override void ExecuteAction(FormSubmitContext formSubmitContext, string parameters)
        {
            SalesForceIFTTTSettings _salesForceIFTTTSettings =
                JsonConvert.DeserializeObject<SalesForceIFTTTSettings>(parameters);

            if (_salesForceIFTTTSettings != null)
            {
                AccountItem =
                    Factory.GetDatabase(Constants.DBNames.masterDB).GetItem(_salesForceIFTTTSettings.accountid);

                EventItem =
                    Factory.GetDatabase(Constants.DBNames.masterDB).GetItem(_salesForceIFTTTSettings.eventid);

            }

            base.ExecuteAction(formSubmitContext, parameters);
        }


        /// <summary>
        /// Executes the action with the specified <paramref name="data" />.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="formSubmitContext">The form submit context.</param>
        /// <returns>
        ///   <c>true</c> if the action is executed correctly; otherwise <c>false</c>
        /// </returns>
        protected override bool Execute(string data, FormSubmitContext formSubmitContext)
        {
            try
            {
                Assert.ArgumentNotNull(formSubmitContext, nameof(formSubmitContext));
                Assert.ArgumentNotNull(AccountItem, nameof(AccountItem));
                Assert.ArgumentNotNull(EventItem, nameof(EventItem));

                if (AccountItem == null || EventItem == null)
                    throw new Exception("Account Item or/and Event Item are not exist..");
                
                var makerKey = string.Empty;
                var eventName = string.Empty;

                makerKey = AccountItem.Fields[Templates.Templates.Account.Fields.MakerKey].Value;
                eventName = EventItem.Fields[Templates.Templates.Event.Fields.EventName].Value;

                if (string.IsNullOrWhiteSpace(makerKey) || string.IsNullOrWhiteSpace(eventName))
                    throw new Exception("Account value or/and Event value are empty..");

                var value1 = ((Sitecore.ExperienceForms.Mvc.Models.Fields.InputViewModel<string>)(formSubmitContext.Fields[0])).Value;
                var value2 = ((Sitecore.ExperienceForms.Mvc.Models.Fields.InputViewModel<string>)(formSubmitContext.Fields[1])).Value;
                var value3 = ((Sitecore.ExperienceForms.Mvc.Models.Fields.InputViewModel<string>)(formSubmitContext.Fields[2])).Value;

                var _values = new string[] { value1, value2, value3 };

                // call IFTTT service
                var iftttService = Sitecore.DependencyInjection.ServiceLocator.ServiceProvider.GetService<IIftttService>();
                iftttService.Trigger(makerKey, eventName, _values);

                if (!formSubmitContext.HasErrors)
                {
                    Logger.Info(Invariant($"Form {formSubmitContext.FormId} submitted successfully."), this);
                }
                else
                {
                    Logger.Warn(Invariant($"Form {formSubmitContext.FormId} submitted with errors: {string.Join(", ", formSubmitContext.Errors.Select(t => t.ErrorMessage))}."), this);
                }
                return true;
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
                return false;
            }
        }
    }
}
