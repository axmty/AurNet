namespace AurNet.Http
{
    /// <summary>
    /// Fields by which a search can be performed when using the 'search' AUR API.
    /// <see href="https://wiki.archlinux.org/index.php/Aurweb_RPC_interface#search">Details in the wiki.</see>
    /// </summary>
    public enum SearchField
    {
        /// <summary>
        /// Search by name.
        /// </summary>
        Name,

        /// <summary>
        /// Search by name and description.
        /// </summary>
        NameDesc,

        /// <summary>
        /// Search by maintainer.
        /// </summary>
        Maintainer,

        /// <summary>
        /// Search packages that depend on...
        /// </summary>
        Depends,

        /// <summary>
        /// Search packages that makedepend on...
        /// </summary>
        MakeDepends,

        /// <summary>
        /// Search packages that optdepend on...
        /// </summary>
        OptDepends,

        /// <summary>
        /// Search packages that checkdepend on...
        /// </summary>
        CheckDepends,
    }
}
