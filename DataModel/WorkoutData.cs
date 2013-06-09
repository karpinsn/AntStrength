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
  public class WorkoutData
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

  public class WorkoutDataSource
  {
    private ObservableCollection<WorkoutData> _WorkoutData = new ObservableCollection<WorkoutData>( );
    public ObservableCollection<WorkoutData> WorkoutData
    {
      get { return this._WorkoutData; }
    }

    public WorkoutDataSource()
    {
      WorkoutData data = new WorkoutData();
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
      this.WorkoutData.Add( data );

      WorkoutData data2 = new WorkoutData();

      Lift lift3 = new Lift();
      lift3.Name = "Bench Press";
      lift3.Sets.Add(new LiftingSet { Weight = 45, Reps = 5 });
      lift3.Sets.Add(new LiftingSet { Weight = 65, Reps = 5 });
      lift3.Sets.Add(new LiftingSet { Weight = 115, Reps = 2 });
      data2.Lifts.Add(lift3);

      data2.Date = new DateTime(2013, 1, 5);
      this.WorkoutData.Add(data2);
    }
  }
}
