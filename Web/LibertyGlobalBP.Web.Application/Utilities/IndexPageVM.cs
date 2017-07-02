namespace LibertyGlobalBP.Web.Application.Utilities
{

    public class IndexPageVM
    {
        public IndexPageVM()
        {
        }

        public IndexPageVM(Section page)
        {
            this.Page = page;
        }

        public IndexPageVM(Section page, Section subpage)
            : this(page)
        {
            this.Subpage = subpage;
        }

        public Section? Page { get; set; }

        public Section? Subpage { get; set; }

    }
}
