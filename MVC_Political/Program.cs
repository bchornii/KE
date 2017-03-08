using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Political
{
    public class Model
    {
        private List<long> _votes;
        private readonly List<string> _parties;
        private readonly List<Observer> _registry;

        public Model(List<string> parties)
        {
            _parties = parties;
            _registry = new List<Observer>();
        }

        public void ManuallyUpdateEvent() => Notify();

        // access interface for modification from controller
        public virtual void ClearVotes() { }
        public virtual void ChangeVote(string party, long vote) { }

        // factory functions for view access to data
        public IEnumerable<long> Votes => _votes;
        public IEnumerable<string> Parties => _parties;

        // observer
        public void Attach(Observer observer) => _registry.Add(observer);
        public void Detach(Observer observer) => _registry.Remove(observer);
        private void Notify()
        {
            _registry.ForEach(o => o.Update());
        }
    }

    public abstract class Observer
    {
        public abstract void Update();
    }

    public abstract class View : Observer, IDisposable
    {
        public Model Model { get; }
        public Controller Controller { get; set; }

        protected View(Model model)
        {
            Model = model;           
            Model.Attach(this);
        }

        public override void Update()
        {
            Console.WriteLine("Update view");
        }

        public abstract void Draw();

        public virtual void Initialize()
        {
            Controller = GetController();
        }

        public virtual Controller GetController() => new Controller(this);

        public void Dispose()
        {
            Model.Detach(this);
        }
    }

    public class BarChartView : View
    {
        public BarChartView(Model model) : 
            base(model)
        {
        }

        public override Controller GetController() => new BarChartController(this);

        public override void Update()
        {
            Console.WriteLine("Update bar view");
        }

        public override void Draw()
        {
            Console.WriteLine("Draw bar chart");
        }
    }

    public class TableView : View
    {
        public TableView(Model model) 
            : base(model)
        {
        }

        public override Controller GetController() => new TableController(this);

        public override void Update()
        {
            Console.WriteLine("Update table view");
        }

        public override void Draw()
        {
            Console.WriteLine("Table draw");
        }
    }

    public class Controller : Observer, IDisposable
    {
        protected readonly Model _model;
        protected readonly View _view;

        public Controller(View view)
        {
            _view = view;
            _model = _view.Model;
            _model.Attach(this);
        }
        public override void Update()
        {
            Console.WriteLine("Update controller");
        }

        public void Dispose()
        {
            _model.Detach(this);
        }
    }

    public class BarChartController : Controller
    {
        public BarChartController(View view) 
            : base(view)
        {
        }

        public override void Update()
        {
            Console.WriteLine("Update bar controller");
        }

        public virtual void HandleEvent(string eventName)
        {
            _model.ChangeVote("party2", 20);
        }
    }

    public class TableController : Controller
    {
        public TableController(View view) 
            : base(view)
        {
        }

        public override void Update()
        {
            Console.WriteLine("Update table controller");
        }

        public virtual void HandleEvent(string eventName)
        {
            _model.ChangeVote("party", 10);
        }
    }

    internal class Program
    {
        public static void Main()
        {
            var parties = new List<string> {"black", "red", "oother"};
            var model = new Model(parties);

            // init views
            var tableView = new TableView(model);
            tableView.Initialize();

            var barChart = new BarChartView(model);
            barChart.Initialize();

            model.ManuallyUpdateEvent();

            Console.Read();
        }
    }
}
