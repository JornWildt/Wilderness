using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuttingEdge.Conditions;
using Wilderness.Game.Core.Components;

namespace Wilderness.Game.Core.Implementation
{
  public class InMemoryEntityRepository : IEntityRepository
  {
    private Dictionary<EntityId, Entity> Entities { get; set; }

    private Dictionary<Type, List<IComponent>> Components { get; set; }


    public InMemoryEntityRepository()
    {
      Entities = new Dictionary<EntityId, Entity>();
      Components = new Dictionary<Type, List<IComponent>>();
    }


    public void AddEntity(Entity e)
    {
      Condition.Requires(e, nameof(e)).IsNotNull();

      if (Entities.ContainsKey(e.Id))
        throw new InvalidOperationException($"Cannot add entity with ID {e.Id} twice.");

      Entities[e.Id] = e;

      if (e.Components != null)
      {
        foreach (var c in e.Components)
        {
          if (c != null)
          {
            Type t = c.GetType();
            if (!Components.ContainsKey(t))
              Components[t] = new List<IComponent>();
            Components[t].Add(c);
          }
        }
      }
    }


    public IEnumerable<Entity> GetAllEntities()
    {
      return Entities.Values;
    }


    public IEnumerable<TC1> GetComponents<TC1>()
      where TC1 : IComponent
    {
      if (!Components.ContainsKey(typeof(TC1)))
        return Enumerable.Empty<TC1>();

      return Components[typeof(TC1)].Cast<TC1>();
    }


    public IEnumerable<Tuple<TC1, TC2>> GetComponents<TC1, TC2>()
      where TC1 : IComponent
      where TC2 : IComponent
    {
      return GetComponents<TC1>()
        .Join(GetComponents<TC2>(), c => c.EntityId, c => c.EntityId, (c1,c2) => new Tuple<TC1, TC2>(c1,c2));
    }
  }
}
