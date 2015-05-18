
namespace Zoo
{
    //Does not follow design pattern, but will simplify the code    
    public static class AnimalIdGenerator
    {
        private static int _id;
        private static readonly object SyncObj = new object();

        public static int GetNewId()
        {
            int resId;
            lock (SyncObj)
            {
                _id++;
                resId = _id;
            }

            return resId;
        }
         
    }
}