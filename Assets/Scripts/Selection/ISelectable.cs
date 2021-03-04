namespace Hexaplex.Selection {
	public interface ISelectable
    {
        bool IsSelected();

        void Select();

        void Deselect();
    }
}