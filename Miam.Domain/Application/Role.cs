namespace Miam.Domain.Application
{
    // Voir notes ci-dessous

    public static class Role
    {
        public const string Admin = "Admin";
        public const string Writer = "Writer";
    }
}

// Note 1
// Attention de ne pas corrompre la BD avant de modifier ou supprimer un rôle dans la classe ci-dessus.
// Si vous devez modifier ou supprimer le nom d'un rôle, il faut s'assurer de faire les changements appropriés dans la BD 
// à l'aide du fichier de configuration de la migration.

// Exemple d'un renommage d'un rôle:
//
   //public override void Up()
   //     {
   //         Sql("Update MiamRoles Set [RoleName] = 'Administrateur' Where [RoleName] = 'Admin'");
   //         Sql("Update MiamRoles Set [RoleName] = 'Chroniqueur' Where [RoleName] = 'Writer'");
   //     }

   //     public override void Down()
   //     {
   //         Sql("Update MiamRoles Set [RoleName] = 'Admin' Where [RoleName] = 'Administrateur'");
   //         Sql("Update MiamRoles Set [RoleName] = 'Writer' Where [RoleName] = 'Chroniqueur'");
   //     }


// Note 2
// L’utilisation d'un enum est aussi envisageable. Par contre, l'annotation [Authorize] ne fonctionne qu'avec des string.
// Pour pouvoir utiliser un enum, il faut réécrire le code de l'attribut [Authorize] afin d'accepter des enums.
// Voir http://stackoverflow.com/questions/1148312/asp-net-mvc-decorate-authorize-with-multiple-enums)
