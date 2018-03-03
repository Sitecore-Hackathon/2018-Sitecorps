namespace Community.Feature.IFTTT.Services
{
    public interface IThresholdService {
        bool IsMet(int threshold, string uniqueKey);
    }

    /// <summary>
    /// Persist Threshold counts across IIS resets and over all servers in scaled instance
    /// </summary>
    public class ThresholdService : IThresholdService
    {
        public bool IsMet(int threshold, string uniqueKey) {

            if (threshold <= 0)
                return true;

            var key = $"ifttt_{uniqueKey}"; // set prefix to group usage and avoid conflicts
            var db = Sitecore.Data.Database.GetDatabase("core");
            var i = db.PropertyStore.GetIntValue(key, 0);
            
            if (++i >= threshold)
            {
                // Met, reset
                db.PropertyStore.SetIntValue(key, 0);
                return true;
            }
            else {
                // Store incremented value
                db.PropertyStore.SetIntValue(key, i);
                return false;
            }

        }        
    }
}