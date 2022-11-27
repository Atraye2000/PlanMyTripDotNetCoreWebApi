namespace my_appApi.models
{
    public class AdminPayload
    {
        private List<Admin> list;

        public List<Admin> Admins { get; set; }

        public int Count { get; set; }

        public AdminPayload(List<Admin> Admins)
        {
            this.Admins = Admins;
            // this.Count = Count;
        }
    }
}
