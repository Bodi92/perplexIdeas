using Infrastructure;


namespace Factory
{
    public class BankIdeasFactory
    {
        public static BankIdea CreateBanKidea()
        {
            return new BankIdea();
        }
    }
}
