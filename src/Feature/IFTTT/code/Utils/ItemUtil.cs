using Sitecore.Data;
using Sitecore.Data.Items;

namespace Community.Feature.IFTTT.Utils
{
    public static class ItemUtil
    {
        public static Item GetItemById(string id, Database db = null)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            
            return GetItemById(ID.TryParse(id, out ID itemId) ? itemId : null);
        }

        public static Item GetItemById(ID id, Database db = null)
        {
            if (ID.IsNullOrEmpty(id)) return null;

            db = db ?? Sitecore.Context.ContentDatabase ?? Sitecore.Context.Database;

            return db?.GetItem(id);
        }
    }
}