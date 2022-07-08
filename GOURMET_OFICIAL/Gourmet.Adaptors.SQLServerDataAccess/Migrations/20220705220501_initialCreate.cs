using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gourmet.Adaptors.SQLServerDataAccess.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Administrador",
                columns: table => new
                {
                    Id_Admin = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Contraseña = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Fecha_Registro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Administrador", x => x.Id_Admin);
                });

            migrationBuilder.CreateTable(
                name: "tb_CategoriaBebida",
                columns: table => new
                {
                    Id_CategoriaBebida = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_CategoriaBebida", x => x.Id_CategoriaBebida);
                });

            migrationBuilder.CreateTable(
                name: "tb_CategoriaPlato",
                columns: table => new
                {
                    Id_CategoriaPlato = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_CategoriaPlato", x => x.Id_CategoriaPlato);
                });

            migrationBuilder.CreateTable(
                name: "tb_Usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Contraseña = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Fecha_Registro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Usuario", x => x.Id_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "tb_Bebida",
                columns: table => new
                {
                    Id_Bebida = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Precio = table.Column<int>(nullable: false),
                    Fecha_Registro = table.Column<DateTime>(nullable: false),
                    Id_CategoriaBebida = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Bebida", x => x.Id_Bebida);
                    table.ForeignKey(
                        name: "FK_tb_Bebida_tb_CategoriaBebida_Id_CategoriaBebida",
                        column: x => x.Id_CategoriaBebida,
                        principalTable: "tb_CategoriaBebida",
                        principalColumn: "Id_CategoriaBebida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Plato",
                columns: table => new
                {
                    Id_Plato = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Precio = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Fecha_Registro = table.Column<DateTime>(nullable: false),
                    Id_CategoriaPlato = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Plato", x => x.Id_Plato);
                    table.ForeignKey(
                        name: "FK_tb_Plato_tb_CategoriaPlato_Id_CategoriaPlato",
                        column: x => x.Id_CategoriaPlato,
                        principalTable: "tb_CategoriaPlato",
                        principalColumn: "Id_CategoriaPlato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Menu",
                columns: table => new
                {
                    Id_Menu = table.Column<Guid>(nullable: false),
                    Id_Bebida = table.Column<Guid>(nullable: false),
                    Id_Plato = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Menu", x => new { x.Id_Menu, x.Id_Plato, x.Id_Bebida });
                    table.ForeignKey(
                        name: "FK_tb_Menu_tb_Bebida_Id_Bebida",
                        column: x => x.Id_Bebida,
                        principalTable: "tb_Bebida",
                        principalColumn: "Id_Bebida",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Menu_tb_Plato_Id_Plato",
                        column: x => x.Id_Plato,
                        principalTable: "tb_Plato",
                        principalColumn: "Id_Plato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_PedidoVenta",
                columns: table => new
                {
                    Id_Pedido = table.Column<Guid>(nullable: false),
                    Subtotal = table.Column<int>(nullable: false),
                    Cantidad_Platos = table.Column<int>(nullable: false),
                    Cantidad_Bebidas = table.Column<int>(nullable: false),
                    Fecha_Venta = table.Column<DateTime>(nullable: false),
                    Id_Usuario = table.Column<Guid>(nullable: false),
                    Id_Plato = table.Column<Guid>(nullable: false),
                    Id_Bebida = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_PedidoVenta", x => x.Id_Pedido);
                    table.ForeignKey(
                        name: "FK_tb_PedidoVenta_tb_Bebida_Id_Bebida",
                        column: x => x.Id_Bebida,
                        principalTable: "tb_Bebida",
                        principalColumn: "Id_Bebida",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_PedidoVenta_tb_Plato_Id_Plato",
                        column: x => x.Id_Plato,
                        principalTable: "tb_Plato",
                        principalColumn: "Id_Plato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_PedidoVenta_tb_Usuario_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "tb_Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_DetallePedido",
                columns: table => new
                {
                    Id_Detalle_Pedido = table.Column<Guid>(nullable: false),
                    Id_Pedido = table.Column<Guid>(nullable: false),
                    Monto_total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_DetallePedido", x => x.Id_Detalle_Pedido);
                    table.ForeignKey(
                        name: "FK_tb_DetallePedido_tb_PedidoVenta_Id_Pedido",
                        column: x => x.Id_Pedido,
                        principalTable: "tb_PedidoVenta",
                        principalColumn: "Id_Pedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Bebida_Id_CategoriaBebida",
                table: "tb_Bebida",
                column: "Id_CategoriaBebida");

            migrationBuilder.CreateIndex(
                name: "IX_tb_DetallePedido_Id_Pedido",
                table: "tb_DetallePedido",
                column: "Id_Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Menu_Id_Bebida",
                table: "tb_Menu",
                column: "Id_Bebida");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Menu_Id_Plato",
                table: "tb_Menu",
                column: "Id_Plato");

            migrationBuilder.CreateIndex(
                name: "IX_tb_PedidoVenta_Id_Bebida",
                table: "tb_PedidoVenta",
                column: "Id_Bebida");

            migrationBuilder.CreateIndex(
                name: "IX_tb_PedidoVenta_Id_Plato",
                table: "tb_PedidoVenta",
                column: "Id_Plato");

            migrationBuilder.CreateIndex(
                name: "IX_tb_PedidoVenta_Id_Usuario",
                table: "tb_PedidoVenta",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Plato_Id_CategoriaPlato",
                table: "tb_Plato",
                column: "Id_CategoriaPlato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Administrador");

            migrationBuilder.DropTable(
                name: "tb_DetallePedido");

            migrationBuilder.DropTable(
                name: "tb_Menu");

            migrationBuilder.DropTable(
                name: "tb_PedidoVenta");

            migrationBuilder.DropTable(
                name: "tb_Bebida");

            migrationBuilder.DropTable(
                name: "tb_Plato");

            migrationBuilder.DropTable(
                name: "tb_Usuario");

            migrationBuilder.DropTable(
                name: "tb_CategoriaBebida");

            migrationBuilder.DropTable(
                name: "tb_CategoriaPlato");
        }
    }
}
