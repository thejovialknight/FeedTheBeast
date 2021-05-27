public interface ISelectable
{
    void Select(int thisIndex);
    void Deselect();
    void Hover();
    void HoverLeave();
}
