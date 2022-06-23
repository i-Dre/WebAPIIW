using Main.DataRepository;


namespace TradeService.DataRepository.Repositories
{
    public class TradeRepository : Repository, ITradeRepository
    {
        private readonly TradeDbContext _context;

        public TradeRepository(TradeDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
