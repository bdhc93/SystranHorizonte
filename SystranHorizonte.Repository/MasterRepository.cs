namespace SystranHorizonte.Repository
{
    public abstract class MasterRepository
    {
        private SystranHorizonteContext _context;

        public MasterRepository()
        {
            if (_context == null)
                _context = new SystranHorizonteContext();
        }

        protected SystranHorizonteContext Context
        {
            get { return _context; }
        }
    }
}
