using UnityEngine;

namespace Hexaplex.Battles {
	public interface IParticipant
    {
        string Name { get; }

        ControllerType ControllerType { get; }

        Sprite Picture { get; }
    }

    public static class ParticipantExtensions
    {
        public static bool IsControlledByPlayer(this IParticipant participant)
        {
            return participant.ControllerType == ControllerType.CurrentPlayer 
                || participant.ControllerType == ControllerType.SimulatedPlayer;
        }
    }
}