using System.Collections.Generic;

namespace Hexaplex.Battles {
	public interface ITeam
    {

        List<IActor> Actors { get; }
    }
}