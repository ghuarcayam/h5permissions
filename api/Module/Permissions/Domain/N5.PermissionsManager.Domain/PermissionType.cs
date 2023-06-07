using N5.BuildingBlocks.Domain;


namespace N5.PermissionsManager.Domain
{
    public class PermissionType: Entity
    {
        string _descripcion;
        int _id;
        
        private PermissionType() 
        {
        
        }
        public PermissionType(string descripcion) 
        {
            _descripcion = descripcion;
        }
        public string Descripcion { get => _descripcion; }
        public int Id { get => _id; private set => _id = value; }
    }
}
