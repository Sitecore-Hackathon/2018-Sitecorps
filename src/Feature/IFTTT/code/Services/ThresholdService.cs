namespace Community.Feature.IFTTT.Services
{

    public interface IThresholdService {
        bool IsMet(int threshold, string uniqueKey);
    }

    public class ThresholdService : IThresholdService
    {
        public bool IsMet(int threshold, string uniqueKey) {
            // TODO: Implement static ConcurrentDictionary or Database.Properties to track threshold increments (clear after isMet == true)
            return true;
        }        
    }
}