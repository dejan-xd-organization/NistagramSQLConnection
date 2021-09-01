using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NistagramSQLConnection.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    region = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    street = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    streetNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    postCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "wallpost",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    timePublis = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    imagePost = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    postDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isPublic = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallpost", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    profileImg = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sex = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    addressId = table.Column<long>(type: "bigint", nullable: true),
                    relationship = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    dateOfRegistration = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    isPublicProfile = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    roleId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_address_addressId",
                        column: x => x.addressId,
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_role_roleId",
                        column: x => x.roleId,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "chatbox",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    meid = table.Column<long>(type: "bigint", nullable: true),
                    youid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatbox", x => x.id);
                    table.ForeignKey(
                        name: "FK_chatbox_user_meid",
                        column: x => x.meid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_chatbox_user_youid",
                        column: x => x.youid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    timeDateComments = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    userId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_comment_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "follower",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dateOfFollowing = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: true),
                    accepted = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_follower", x => x.id);
                    table.ForeignKey(
                        name: "FK_follower_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "following",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dateOfFollowing = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_following", x => x.id);
                    table.ForeignKey(
                        name: "FK_following_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message", x => x.id);
                    table.ForeignKey(
                        name: "FK_message_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reaction",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    userId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reaction", x => x.id);
                    table.ForeignKey(
                        name: "FK_reaction_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserPosts",
                columns: table => new
                {
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    postId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPosts", x => new { x.postId, x.userId });
                    table.ForeignKey(
                        name: "FK_UserPosts_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPosts_wallpost_postId",
                        column: x => x.postId,
                        principalTable: "wallpost",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostComments",
                columns: table => new
                {
                    postId = table.Column<long>(type: "bigint", nullable: false),
                    commentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => new { x.postId, x.commentId });
                    table.ForeignKey(
                        name: "FK_PostComments_comment_commentId",
                        column: x => x.commentId,
                        principalTable: "comment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostComments_wallpost_postId",
                        column: x => x.postId,
                        principalTable: "wallpost",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserFollowers",
                columns: table => new
                {
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    followerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowers", x => new { x.userId, x.followerId });
                    table.ForeignKey(
                        name: "FK_UserFollowers_follower_followerId",
                        column: x => x.followerId,
                        principalTable: "follower",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFollowers_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserFollowings",
                columns: table => new
                {
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    followerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowings", x => new { x.userId, x.followerId });
                    table.ForeignKey(
                        name: "FK_UserFollowings_following_followerId",
                        column: x => x.followerId,
                        principalTable: "following",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFollowings_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChatBoxMessages",
                columns: table => new
                {
                    chatBoxId = table.Column<long>(type: "bigint", nullable: false),
                    messageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatBoxMessages", x => new { x.chatBoxId, x.messageId });
                    table.ForeignKey(
                        name: "FK_ChatBoxMessages_chatbox_chatBoxId",
                        column: x => x.chatBoxId,
                        principalTable: "chatbox",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatBoxMessages_message_messageId",
                        column: x => x.messageId,
                        principalTable: "message",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostReactions",
                columns: table => new
                {
                    postId = table.Column<long>(type: "bigint", nullable: false),
                    reactionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReactions", x => new { x.postId, x.reactionId });
                    table.ForeignKey(
                        name: "FK_PostReactions_reaction_reactionId",
                        column: x => x.reactionId,
                        principalTable: "reaction",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReactions_wallpost_postId",
                        column: x => x.postId,
                        principalTable: "wallpost",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_chatbox_meid",
                table: "chatbox",
                column: "meid");

            migrationBuilder.CreateIndex(
                name: "IX_chatbox_youid",
                table: "chatbox",
                column: "youid");

            migrationBuilder.CreateIndex(
                name: "IX_ChatBoxMessages_messageId",
                table: "ChatBoxMessages",
                column: "messageId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_userId",
                table: "comment",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_follower_userId",
                table: "follower",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_following_userId",
                table: "following",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_message_userId",
                table: "message",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_commentId",
                table: "PostComments",
                column: "commentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_reactionId",
                table: "PostReactions",
                column: "reactionId");

            migrationBuilder.CreateIndex(
                name: "IX_reaction_userId",
                table: "reaction",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_user_addressId",
                table: "user",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_user_email_username",
                table: "user",
                columns: new[] { "email", "username" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_roleId",
                table: "user",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowers_followerId",
                table: "UserFollowers",
                column: "followerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowings_followerId",
                table: "UserFollowings",
                column: "followerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPosts_userId",
                table: "UserPosts",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatBoxMessages");

            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "PostReactions");

            migrationBuilder.DropTable(
                name: "UserFollowers");

            migrationBuilder.DropTable(
                name: "UserFollowings");

            migrationBuilder.DropTable(
                name: "UserPosts");

            migrationBuilder.DropTable(
                name: "chatbox");

            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "reaction");

            migrationBuilder.DropTable(
                name: "follower");

            migrationBuilder.DropTable(
                name: "following");

            migrationBuilder.DropTable(
                name: "wallpost");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
