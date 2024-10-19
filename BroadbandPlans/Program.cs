using System.Collections.Generic;

namespace BroadbandPlans
{
    interface IBroadbandPlan
    {
        public int GetBroadbandPlanAmount();
    }
    public class Program
    {
        public void Main(string[] args)
        {
            var plans = new List<IBroadbandPlan>
            {
                new Black(true, 50),
                new Black(false, 10),
                new Gold(true, 30),
                new Black(true, 20),
                new Gold(false, 20),
            };
            var subscriptionPlans = new SubscribePlan(plans);
            var result = subscriptionPlans.GetSubscriptionPlan();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Item1},{item.Item2}");
            }
        }
    }
    public class Black : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 3000;
        public Black(bool isSubscriptionValid, int discountPercentage)
        {
            this._isSubscriptionValid = isSubscriptionValid;
            if (discountPercentage < 0 || discountPercentage > 50)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this._discountPercentage = discountPercentage;
            }
        }
        public int GetBroadbandPlanAmount()
        {
            int discountPrice = 0;
            if (_isSubscriptionValid)
            {
                discountPrice = PlanAmount - PlanAmount * _discountPercentage / 100;
                return discountPrice;
            }
            else
            {
                discountPrice = PlanAmount;
                return discountPrice;
            }
        }
    }
    public class Gold : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 1500;

        public Gold(bool isSubscriptionValid, int discountPercentage)
        {
            this._isSubscriptionValid = isSubscriptionValid;
            if (discountPercentage < 0 || discountPercentage > 30)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this._discountPercentage = discountPercentage;
            }
        }
        public int GetBroadbandPlanAmount()
        {
            int discountPrice = 0;
            if (_isSubscriptionValid)
            {
                discountPrice = PlanAmount - PlanAmount * _discountPercentage / 100;
                return discountPrice;
            }
            else
            {
                discountPrice = PlanAmount;
                return discountPrice;
            }
        }
    }
    class SubscribePlan
    {
        private readonly IList<IBroadbandPlan> _broadbandPlans;
        public SubscribePlan(IList<IBroadbandPlan> broadbandPlans)
        {
            if (!(broadbandPlans == null))
            {

                this._broadbandPlans = broadbandPlans;
            }
            else
            {

                throw new ArgumentNullException();

            }

        }


        public IList<Tuple<string, int>> GetSubscriptionPlan()
        {
            int count = 0;
            IList<Tuple<string, int>> list = new List<Tuple<string, int>>();
            foreach (var i in _broadbandPlans)
            {
                count++;
                var result = new Tuple<string, int>[count];
                int c = 0;
                foreach (var item in _broadbandPlans)
                {
                    c++;
                    string planType = item.GetType().Name;
                    int amount = item.GetBroadbandPlanAmount();

                    result[c] = new Tuple<string, int>(planType, amount);
                }
                for (int j = 0; j < result.Length; j++)
                {
                    list.Add(result[j]);
                }

                if (_broadbandPlans == null)
                {
                    throw new ArgumentNullException();
                }
            }
            return list;

        }
    }
}

