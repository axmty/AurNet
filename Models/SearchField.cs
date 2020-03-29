namespace AurNet.Models
{
    /// <summary>
    /// Fields by which a search can be performed when using the 'search' AUR API.
    /// <see href="https://wiki.archlinux.org/index.php/Aurweb_RPC_interface#search">Details in the wiki.</see>
    /// </summary>
    public enum SearchField
    {
        Name,
        NameDesc,
        Maintainer,
        Depends,
        MakeDepends,
        OptDepends,
        CheckDepends,
    }
}
