namespace ASCII_Donut.Engine
{
    public interface IVoxelModel
    {
        public Point Position { get; set; }
        public Rotation Rotation { get; set; }
        public Voxel[] PreRendered { get; }
    }
}
