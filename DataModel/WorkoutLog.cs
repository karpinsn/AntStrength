using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntStrength.DataModel
{
  // Workout
  // - Multiple lifts
  // - - Each lift has multiple setst
  // - - - Each set has multiple reps at specific weight
  public class WorkoutLog
  {
    public DateTime Date { get; set; }
    private List<Lift> _Lifts = new List<Lift>( );
    public List<Lift> Lifts 
    {
      get { return this._Lifts; }
    }
  }

  // Holds info for a single lift
  public class Lift
  {
    public string Name { get; set; }
    private List<LiftingSet> _Sets = new List<LiftingSet>();
    public List<LiftingSet> Sets
    {
      get { return this._Sets; }
    }
  }

  public class LiftingSet
  {
    public int Weight { get; set; }
    public int Reps { get; set; }
  }

  public class WorkingSetLog
  {
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public int Weight { get; set; }
  }

  public class WorkoutDataViewModel
  {
    private ObservableCollection<WorkoutLog> _WorkoutLog = new ObservableCollection<WorkoutLog>();
    public ObservableCollection<WorkoutLog> WorkoutLog
    {
      get { return this._WorkoutLog; }
    }

    private ObservableCollection<WorkingSetLog> _WorkingSetLog = new ObservableCollection<WorkingSetLog>();
    public ObservableCollection<WorkingSetLog> WorkingSetLog
    {
      get
      {
        return _WorkingSetLog;
      }
    }

    public WorkoutDataViewModel()
    {
      WorkoutLog.CollectionChanged += WorkoutLog_CollectionChanged;
    }

    //[TODO:Comeback and check this]
    void WorkoutLog_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
      // Need to update the WorkingSetLog
      switch(e.Action)
      {
        case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
          // Add the new lifts to our working set log
          var newLog = sender as ObservableCollection<WorkoutLog>;
          if (null == newLog)
            { throw new NotImplementedException(); }

          foreach (var log in newLog)
          {
            var lifts = (from l in log.Lifts select l.Name).Distinct();
            foreach( var lift in lifts)
            {
              WorkingSetLog.Add(new WorkingSetLog { Date = log.Date, Name = lift, Weight = 40 });
            }
          }

          break;
        default:
          throw new NotImplementedException();
      }
    }
  }

  public class WorkoutDataSource : WorkoutDataViewModel
  {
    public WorkoutDataSource()
    {
      WorkoutLog data = new WorkoutLog();
      Lift lift1 = new Lift();
      lift1.Name = "Overhead Press";
      lift1.Sets.Add(new LiftingSet { Weight = 50, Reps = 5 });
      lift1.Sets.Add(new LiftingSet { Weight = 60, Reps = 5 });
      lift1.Sets.Add(new LiftingSet { Weight = 70, Reps = 5 });
      data.Lifts.Add(lift1);

      Lift lift2 = new Lift();
      lift2.Name = "Deadlift";
      lift2.Sets.Add(new LiftingSet { Weight = 135, Reps = 5 });
      lift2.Sets.Add(new LiftingSet { Weight = 225, Reps = 5 });
      lift2.Sets.Add(new LiftingSet { Weight = 185, Reps = 3 });
      data.Lifts.Add(lift2);

      data.Date = new DateTime(2013, 1, 3);
      this.WorkoutLog.Add(data);

      WorkoutLog data2 = new WorkoutLog();

      Lift lift3 = new Lift();
      lift3.Name = "Bench Press";
      lift3.Sets.Add(new LiftingSet { Weight = 45, Reps = 5 });
      lift3.Sets.Add(new LiftingSet { Weight = 65, Reps = 5 });
      lift3.Sets.Add(new LiftingSet { Weight = 115, Reps = 2 });
      data2.Lifts.Add(lift3);

      data2.Date = new DateTime(2013, 1, 5);
      this.WorkoutLog.Add(data2);

      WorkoutLog data3 = new WorkoutLog();
      Lift lift4 = new Lift();
      lift4.Name = "Overhead Press";
      lift4.Sets.Add(new LiftingSet { Weight = 45, Reps = 5 });
      lift4.Sets.Add(new LiftingSet { Weight = 55, Reps = 5 });
      lift4.Sets.Add(new LiftingSet { Weight = 65, Reps = 5 });
      data3.Lifts.Add(lift4);

      Lift lift5 = new Lift();
      lift5.Name = "Deadlift";
      lift5.Sets.Add(new LiftingSet { Weight = 125, Reps = 5 });
      lift5.Sets.Add(new LiftingSet { Weight = 215, Reps = 5 });
      lift5.Sets.Add(new LiftingSet { Weight = 175, Reps = 3 });
      data3.Lifts.Add(lift5);

      data3.Date = new DateTime(2013, 1, 1);
      this.WorkoutLog.Add(data3);
    }
  }
}
