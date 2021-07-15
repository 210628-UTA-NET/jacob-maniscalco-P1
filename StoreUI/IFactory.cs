namespace StoreUI
{
    public interface IFactory
    {
        /// <summary>
        /// Implements the factory design pattern to create menu objects.
        /// </summary>
        /// <param name="pMenu"></param>
        /// <returns>returns an IMenu object for the specified menu</returns>
        IMenu GetMenu(MenuType pMenu);
    }
}