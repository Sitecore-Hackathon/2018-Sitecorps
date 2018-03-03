using Community.Feature.IFTTT.Services;
using Sitecore.Configuration;
using Sitecore.Data.Events;
using Sitecore.Data.Items;
using Sitecore.Events;
using Sitecore.Links;
using System;
using Community.Feature.IFTTT.Constants;


namespace Community.Feature.IFTTT.Events
{
    /// <summary>
    /// Listeners for Item Events; when hit these run the Global IFTTT Event rules under /system/rules/IFTTT Events
    /// </summary>
    public class ItemEventHandler
    {
        protected IRulesService Rules;
        public ItemEventHandler(IRulesService rules)
        {
            Rules = rules;
        }

        protected virtual void RunRules(string eventName, Item item)
        {
            if (!Settings.GetBoolSetting("IFTTT.Enable.EventTriggers", true))
                return;
            
            Rules.RunEventRules(eventName, 
                item,
                item?.TemplateName, 
                item?.Name, 
                item?.Parent?.Name  
            );
        }

        /// <summary>
        /// Called when the item has added.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        /// <contract>
        ///   <requires name="sender" condition="none" />
        ///   <requires name="args" condition="none" />
        /// </contract>
        protected void OnItemAdded(object sender, EventArgs args)
            {
                if (args == null)
                {
                    return;
                }
                Item item = Event.ExtractParameter(args, 0) as Item;
                if (item == null)
                {
                    return;
                }
                this.RunRules("item:added", item);
            }

            /// <summary>
            /// Called when the item has added.
            /// </summary>
            /// <param name="sender">
            /// The sender.
            /// </param>
            /// <param name="args">
            /// The arguments.
            /// </param>
            /// <contract>
            ///   <requires name="sender" condition="none" />
            ///   <requires name="args" condition="none" />
            /// </contract>
            protected void OnItemAddedRemote(object sender, EventArgs args)
            {
                AddedFromTemplateRemoteEventArgs addedFromTemplateRemoteEventArg = args as AddedFromTemplateRemoteEventArgs;
                if (addedFromTemplateRemoteEventArg == null)
                {
                    return;
                }
                this.RunRules("item:added:remote", addedFromTemplateRemoteEventArg.Item);
            }

            /// <summary>
            /// Called when the item has been deleted.
            /// </summary>
            /// <param name="sender">
            /// The sender.
            /// </param>
            /// <param name="args">
            /// The arguments.
            /// </param>
            /// <contract>
            ///   <requires name="sender" condition="none" />
            ///   <requires name="args" condition="none" />
            /// </contract>
            protected void OnItemDeleted(object sender, EventArgs args)
            {
                if (args == null)
                {
                    return;
                }
                Item item = Event.ExtractParameter(args, 0) as Item;
                if (item == null)
                {
                    return;
                }
                this.RunRules("item:deleted", item);
            }

            /// <summary>
            /// Called when the item has been deleted.
            /// </summary>
            /// <param name="sender">
            /// The sender.
            /// </param>
            /// <param name="args">
            /// The arguments.
            /// </param>
            /// <contract>
            ///   <requires name="sender" condition="none" />
            ///   <requires name="args" condition="none" />
            /// </contract>
            protected void OnItemDeletedRemote(object sender, EventArgs args)
            {
                ItemDeletedRemoteEventArgs itemDeletedRemoteEventArg = args as ItemDeletedRemoteEventArgs;
                if (itemDeletedRemoteEventArg == null)
                {
                    return;
                }
                this.RunRules("item:deleted:remote", itemDeletedRemoteEventArg.Item);
            }

        }
    }