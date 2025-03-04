public class SnakeElement {
    public int PositionX {get; set;}
    public int PositionY {get; set;}
    public int Direction {get; set;}
    public SnakeElement(int positionX, int positionY, int direction) {
        PositionX = positionX;
        PositionY = positionY;
        Direction = direction;
    }
}