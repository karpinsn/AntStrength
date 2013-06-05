using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntStrength
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

    public void GetData( )
    {
      LiftingSet set1 = new LiftingSet( );
      set1.Weight = 50;
      set1.Reps = 5;
      Lift lift = new Lift( );
      lift.Name = "Overhead Press";
      lift.Sets.Add( set1 );

      WorkoutData data = new WorkoutData( );
      data.Lifts.Add( lift );

      this.WorkoutData.Add( data );
    }
  }
}
