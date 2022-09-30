using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCampusData.Migrations
{
    public partial class seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("8085339c-07b6-42be-ad10-7df5eb0564ce"), new DateTime(2022, 8, 14, 20, 31, 28, 453, DateTimeKind.Unspecified).AddTicks(3333), "Full Stack Development עם התמחות ב - Microsoft .NET & ReactJS", "קורס פיתוח תוכנה 6 NET." },
                    { new Guid("b21d2e8c-a9c9-4b25-a208-de40f2967b6d"), new DateTime(2022, 8, 14, 20, 27, 32, 723, DateTimeKind.Unspecified).AddTicks(3333), "פיתוח משחקים ב-Unity וכל מה שמסביב", "קורס פיתוח משחקים" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "Country", "CreatedAt", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "PasswordSalt", "Permissions", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { new Guid("1bef51c5-000b-4555-95b9-80184c752b06"), "tel aviv", "ישראל", new DateTime(2022, 8, 21, 13, 2, 8, 90, DateTimeKind.Unspecified).AddTicks(5168), "gwagwa@gwag.com", "דני", 1, "אל", new byte[] { 203, 47, 91, 7, 224, 80, 234, 254, 69, 152, 86, 193, 82, 53, 161, 0, 138, 65, 142, 129, 99, 70, 197, 41, 177, 83, 37, 79, 136, 35, 176, 178, 144, 43, 155, 101, 248, 2, 92, 136, 49, 46, 148, 14, 7, 43, 133, 21, 12, 87, 150, 152, 210, 162, 74, 155, 55, 32, 11, 57, 116, 83, 50, 24 }, new byte[] { 21, 147, 138, 173, 242, 218, 18, 125, 50, 124, 114, 141, 146, 49, 207, 99, 247, 200, 229, 181, 234, 139, 46, 161, 156, 9, 99, 189, 120, 80, 120, 7, 0, 246, 237, 173, 60, 133, 114, 218, 251, 125, 81, 170, 152, 241, 121, 24, 99, 29, 67, 176, 24, 132, 157, 153, 242, 67, 133, 149, 109, 83, 129, 125, 31, 2, 107, 161, 121, 68, 119, 118, 229, 12, 156, 110, 54, 1, 8, 239, 105, 70, 51, 194, 57, 189, 74, 79, 71, 165, 234, 61, 203, 13, 232, 162, 151, 142, 105, 142, 0, 195, 22, 234, 30, 18, 61, 202, 167, 157, 54, 238, 64, 44, 64, 105, 1, 124, 109, 86, 27, 5, 6, 22, 53, 144, 149, 56 }, 1, "0543321541", "test123" },
                    { new Guid("1fb83307-3f4d-4cf7-8df0-d2dc4f8d3860"), "תל-אביב", "ישראל", new DateTime(2022, 8, 14, 19, 23, 47, 890, DateTimeKind.Unspecified).AddTicks(2802), "dani.k1@ga.com", "דניאל", 1, "קריצ'בסקי", new byte[] { 204, 245, 240, 133, 243, 87, 197, 30, 6, 241, 1, 62, 52, 50, 246, 33, 26, 60, 109, 207, 86, 63, 156, 39, 229, 200, 140, 246, 199, 36, 235, 229, 161, 129, 99, 59, 52, 158, 40, 51, 184, 196, 126, 200, 91, 171, 6, 47, 135, 178, 76, 34, 110, 92, 229, 127, 254, 136, 71, 183, 148, 74, 105, 210 }, new byte[] { 151, 66, 238, 37, 57, 135, 60, 114, 239, 254, 85, 236, 198, 147, 3, 177, 162, 35, 224, 157, 247, 234, 133, 13, 64, 149, 54, 85, 210, 251, 61, 255, 8, 154, 188, 121, 63, 175, 230, 198, 204, 28, 182, 181, 17, 33, 3, 136, 47, 191, 84, 74, 88, 113, 0, 240, 241, 228, 226, 145, 179, 86, 60, 129, 125, 222, 211, 241, 107, 247, 98, 88, 35, 193, 197, 67, 217, 129, 76, 30, 198, 118, 125, 248, 10, 190, 6, 43, 157, 60, 216, 34, 109, 102, 76, 151, 178, 140, 2, 175, 160, 144, 187, 40, 236, 86, 130, 81, 58, 124, 51, 127, 6, 51, 242, 168, 68, 159, 117, 146, 134, 199, 24, 101, 205, 51, 173, 112 }, 1, "0542251548", "daniel228" },
                    { new Guid("29bf0827-9f99-4a4b-9dd3-9b7f0d49cfa6"), "תל-אביב-יפו", "ישראל", new DateTime(2022, 8, 19, 21, 15, 28, 815, DateTimeKind.Unspecified).AddTicks(1868), "gagw@gwaga.com", "דן", 1, "לוי", new byte[] { 104, 101, 128, 78, 136, 121, 147, 83, 98, 87, 223, 232, 25, 32, 59, 183, 124, 112, 38, 91, 248, 117, 133, 208, 162, 93, 109, 128, 29, 102, 88, 13, 100, 170, 11, 157, 76, 43, 127, 77, 201, 170, 195, 222, 228, 196, 199, 88, 90, 20, 104, 180, 54, 254, 225, 168, 50, 207, 78, 153, 81, 108, 23, 36 }, new byte[] { 123, 57, 1, 168, 128, 44, 223, 11, 237, 72, 226, 14, 26, 176, 129, 167, 35, 180, 46, 153, 62, 135, 66, 21, 220, 107, 123, 225, 224, 138, 212, 35, 196, 85, 5, 206, 119, 91, 216, 213, 35, 74, 197, 196, 210, 166, 229, 74, 158, 234, 185, 134, 31, 255, 245, 3, 141, 177, 20, 193, 124, 126, 212, 248, 17, 16, 44, 231, 101, 228, 12, 33, 239, 185, 176, 224, 42, 241, 215, 122, 141, 29, 104, 211, 90, 243, 225, 219, 154, 179, 97, 232, 41, 188, 101, 146, 205, 30, 253, 215, 16, 12, 123, 219, 64, 250, 56, 101, 96, 145, 99, 3, 15, 98, 127, 30, 32, 139, 25, 1, 142, 32, 209, 60, 79, 39, 1, 212 }, 1, "0542251548", "newnoob" },
                    { new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "Tel-Aviv", "israel", new DateTime(2022, 8, 13, 23, 22, 59, 582, DateTimeKind.Unspecified).AddTicks(6978), "danek@gmail.com", "אילן", 1, "מאקס", new byte[] { 53, 241, 31, 101, 7, 213, 85, 181, 36, 45, 116, 179, 14, 42, 174, 13, 90, 86, 245, 65, 139, 57, 212, 211, 107, 93, 146, 36, 213, 11, 38, 64, 172, 208, 154, 149, 138, 173, 192, 138, 228, 53, 8, 181, 118, 16, 227, 198, 222, 36, 185, 113, 207, 12, 1, 129, 74, 14, 22, 4, 14, 153, 79, 203 }, new byte[] { 245, 72, 182, 241, 43, 53, 117, 92, 244, 248, 85, 44, 235, 101, 104, 69, 107, 136, 115, 23, 33, 211, 108, 34, 185, 119, 152, 120, 54, 198, 114, 159, 39, 16, 43, 132, 18, 179, 141, 126, 1, 4, 220, 120, 53, 213, 91, 32, 191, 245, 85, 134, 137, 207, 34, 115, 169, 38, 147, 129, 192, 178, 133, 110, 188, 23, 30, 97, 168, 246, 46, 206, 237, 164, 139, 122, 145, 49, 27, 99, 46, 80, 43, 202, 8, 35, 181, 197, 250, 99, 111, 88, 224, 80, 194, 193, 53, 223, 251, 169, 244, 202, 204, 188, 46, 165, 73, 113, 235, 156, 178, 174, 63, 188, 79, 173, 248, 16, 223, 168, 133, 51, 254, 112, 183, 200, 147, 98 }, 2, "0542251548", "daniel" },
                    { new Guid("57b8ecbf-2475-4db1-9d36-ecc338d88445"), "unknown", "ישראל", new DateTime(2022, 8, 19, 13, 0, 11, 768, DateTimeKind.Unspecified).AddTicks(2118), "admin@localhost.com", "מנהל", 1, "מנהל", new byte[] { 193, 110, 68, 131, 165, 214, 94, 173, 49, 191, 219, 95, 71, 88, 114, 25, 208, 209, 52, 36, 240, 59, 61, 159, 123, 51, 24, 2, 234, 151, 99, 143, 58, 241, 129, 184, 202, 130, 107, 96, 165, 177, 126, 129, 8, 251, 85, 113, 121, 247, 245, 77, 93, 35, 134, 221, 149, 245, 137, 24, 205, 57, 238, 167 }, new byte[] { 120, 229, 176, 131, 121, 88, 210, 38, 155, 9, 35, 107, 139, 50, 206, 122, 47, 121, 59, 178, 199, 170, 89, 8, 165, 187, 15, 146, 35, 66, 137, 206, 142, 63, 217, 200, 121, 64, 122, 62, 121, 231, 101, 58, 53, 33, 48, 144, 112, 151, 178, 40, 5, 167, 195, 89, 129, 117, 159, 120, 147, 141, 43, 68, 192, 178, 242, 176, 165, 246, 96, 180, 110, 77, 254, 45, 230, 186, 231, 207, 177, 93, 11, 87, 178, 170, 139, 158, 7, 125, 197, 57, 91, 238, 107, 33, 124, 143, 123, 114, 188, 32, 47, 141, 239, 108, 163, 108, 163, 54, 4, 228, 237, 65, 133, 239, 8, 24, 121, 63, 70, 4, 198, 191, 17, 247, 2, 186 }, 3, "1111111111", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "ClassFinishAt", "ClassStartAt", "CourseId", "CreatedAt", "LecturerId", "Name" },
                values: new object[] { new Guid("323a5ad6-7c0b-4e94-b55e-0e56282d9b4f"), new DateTime(2022, 8, 16, 14, 52, 38, 210, DateTimeKind.Unspecified), new DateTime(2022, 8, 16, 14, 52, 38, 210, DateTimeKind.Unspecified), new Guid("8085339c-07b6-42be-ad10-7df5eb0564ce"), new DateTime(2022, 8, 16, 14, 52, 38, 210, DateTimeKind.Unspecified), null, "D151121MR" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "ClassFinishAt", "ClassStartAt", "CourseId", "CreatedAt", "LecturerId", "Name" },
                values: new object[] { new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 14, 52, 19, 930, DateTimeKind.Unspecified), new DateTime(2022, 8, 16, 14, 52, 19, 930, DateTimeKind.Unspecified), new Guid("8085339c-07b6-42be-ad10-7df5eb0564ce"), new DateTime(2022, 8, 16, 14, 52, 19, 930, DateTimeKind.Unspecified), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "D151121ER" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "ClassFinishAt", "ClassStartAt", "CourseId", "CreatedAt", "LecturerId", "Name" },
                values: new object[] { new Guid("9a6befae-bfe1-4b01-a4fc-2805d4043df7"), new DateTime(2022, 8, 16, 15, 56, 0, 243, DateTimeKind.Unspecified).AddTicks(3333), new DateTime(2022, 8, 16, 15, 56, 0, 243, DateTimeKind.Unspecified).AddTicks(3333), new Guid("b21d2e8c-a9c9-4b25-a208-de40f2967b6d"), new DateTime(2022, 8, 16, 15, 56, 0, 243, DateTimeKind.Unspecified).AddTicks(3333), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "G160822ER" });

            migrationBuilder.InsertData(
                table: "ClassMeetings",
                columns: new[] { "Id", "ClassId", "CreatedAt", "LecturerId", "MeetingUrl", "StartAt", "Title" },
                values: new object[,]
                {
                    { new Guid("000b4f7a-8adf-44db-8081-1fc99845c261"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 11, 330, DateTimeKind.Unspecified), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 14, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("01d65ce9-2754-470c-9967-16446c37b8e4"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 2, 260, DateTimeKind.Unspecified), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 8, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("12d7d085-0271-48c1-b871-bf6e6afc3da0"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 6, 463, DateTimeKind.Unspecified).AddTicks(3333), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 10, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("21d85b05-409e-4da2-a47f-a4d2407a55f5"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 24, 836, DateTimeKind.Unspecified).AddTicks(6667), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 24, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("370704d4-cfae-421b-8d46-a75af528a52a"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 28, 686, DateTimeKind.Unspecified).AddTicks(6667), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 27, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("397aadb6-25d6-4948-97e5-e822994ab562"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 22, 186, DateTimeKind.Unspecified).AddTicks(6667), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 22, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("44772e5b-1cd0-4383-a577-b6fa874e6ab6"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 14, 58, 39, 780, DateTimeKind.Unspecified), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 8, 17, 17, 30, 0, 0, DateTimeKind.Unspecified), "Learn classes and OOP" },
                    { new Guid("4cc825da-6108-4707-85a4-e7574310e5f6"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 15, 196, DateTimeKind.Unspecified).AddTicks(6667), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 17, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("4eb0f4c8-3bb6-4213-8cbf-9761a1c064fa"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 14, 59, 54, 896, DateTimeKind.Unspecified).AddTicks(6667), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("4eba53af-e916-4f26-acb5-0938a085c61c"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 17, 710, DateTimeKind.Unspecified), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 18, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("52178fa5-abcd-4e7f-bcb2-c494b7f2ba98"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 20, 233, DateTimeKind.Unspecified).AddTicks(3333), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 20, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("5e2c5167-9c37-475d-b8c0-7a426e10a02e"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 26, 140, DateTimeKind.Unspecified), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 25, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("60e35fe8-48c4-459d-ace4-5cc242ac6cb1"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 14, 59, 57, 346, DateTimeKind.Unspecified).AddTicks(6667), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 5, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("6471d929-92ff-4555-ad3f-7d3d57e9cb98"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 21, 233, DateTimeKind.Unspecified).AddTicks(3333), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 21, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("6b2385d4-2119-4b86-ba4b-ddfa0e8a3e45"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 12, 563, DateTimeKind.Unspecified).AddTicks(3333), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 15, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("6f878d02-9365-433a-8516-6d7b34d2541e"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 27, 690, DateTimeKind.Unspecified), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 26, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("75c147aa-1076-4b76-82b8-2c62bbe52695"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 29, 730, DateTimeKind.Unspecified), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 28, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("78ae0eb1-cd66-4487-a49d-38539dfdef4b"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 14, 58, 13, 133, DateTimeKind.Unspecified).AddTicks(3333), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 8, 16, 8, 52, 38, 210, DateTimeKind.Unspecified), "Learn .NET basics" },
                    { new Guid("88c52c24-57dd-4505-b3e7-4f1e57be5afd"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 18, 853, DateTimeKind.Unspecified).AddTicks(3333), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 19, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("97dc3d25-d3d7-4d3b-8219-bdf23db0e5c7"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 8, 663, DateTimeKind.Unspecified).AddTicks(3333), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 12, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("9de9a4ae-eb7e-478f-9ef0-f119da36ba23"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 23, 726, DateTimeKind.Unspecified).AddTicks(6667), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 23, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("aca3e42b-2958-4a08-8bae-81a58efe8abb"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 30, 736, DateTimeKind.Unspecified).AddTicks(6667), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 29, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("adcf54e6-f884-4765-8829-6835eea6ace2"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 0, 940, DateTimeKind.Unspecified), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 7, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("af1c538f-5c57-4c8b-9a00-39be3a1c7d69"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 33, 146, DateTimeKind.Unspecified).AddTicks(6667), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 30, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("c322a345-3ab5-47ea-b34a-9b0ebdfe99dc"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 10, 190, DateTimeKind.Unspecified), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 13, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("cc3fc18c-c029-4811-aafd-990c8cb3e95b"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 13, 933, DateTimeKind.Unspecified).AddTicks(3333), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 16, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("d4b7f3e6-3671-4ebe-8d13-d7f1d065f76b"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 14, 59, 56, 40, DateTimeKind.Unspecified), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 4, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("da346543-0244-4b83-b756-9385cd9b5e47"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 3, 496, DateTimeKind.Unspecified).AddTicks(6667), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 9, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("e99cd14b-af7f-42a2-b619-c3306f9e6e51"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 14, 59, 53, 566, DateTimeKind.Unspecified).AddTicks(6667), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 2, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("eccd87e1-cc0b-41a5-9fdd-e855ae1cca91"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 14, 59, 59, 350, DateTimeKind.Unspecified), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 6, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("f296539b-772b-4aa6-8346-7e36fb6e70db"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 15, 0, 7, 493, DateTimeKind.Unspecified).AddTicks(3333), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 11, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" },
                    { new Guid("f9607d6b-c557-4801-81a9-b532bc9fa3d0"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 14, 59, 13, 36, DateTimeKind.Unspecified).AddTicks(6667), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 8, 25, 17, 30, 0, 0, DateTimeKind.Unspecified), "Learn LINQ" },
                    { new Guid("fdc4ec99-271b-457d-a867-040778b1e50a"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 14, 59, 50, 650, DateTimeKind.Unspecified), new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"), "https://us06web.zoom.us/j/83663882593", new DateTime(2022, 9, 1, 17, 30, 0, 0, DateTimeKind.Unspecified), "Generic meeting" }
                });

            migrationBuilder.InsertData(
                table: "UserClasses",
                columns: new[] { "Id", "ClassId", "CreatedAt", "Evaluation", "StudentId" },
                values: new object[,]
                {
                    { new Guid("4b500d50-f6d5-49b9-8cb8-b9dc0646ae7f"), new Guid("9a6befae-bfe1-4b01-a4fc-2805d4043df7"), new DateTime(2022, 8, 16, 15, 57, 2, 686, DateTimeKind.Unspecified).AddTicks(6667), null, new Guid("1fb83307-3f4d-4cf7-8df0-d2dc4f8d3860") },
                    { new Guid("870f4bc7-7b75-44ae-9e9d-e0337693eb0e"), new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"), new DateTime(2022, 8, 16, 14, 54, 46, 870, DateTimeKind.Unspecified), null, new Guid("1fb83307-3f4d-4cf7-8df0-d2dc4f8d3860") },
                    { new Guid("b85a079a-fa35-4966-b8ad-4b98518e56af"), new Guid("9a6befae-bfe1-4b01-a4fc-2805d4043df7"), new DateTime(2022, 8, 19, 21, 19, 36, 200, DateTimeKind.Unspecified), null, new Guid("29bf0827-9f99-4a4b-9dd3-9b7f0d49cfa6") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("000b4f7a-8adf-44db-8081-1fc99845c261"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("01d65ce9-2754-470c-9967-16446c37b8e4"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("12d7d085-0271-48c1-b871-bf6e6afc3da0"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("21d85b05-409e-4da2-a47f-a4d2407a55f5"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("370704d4-cfae-421b-8d46-a75af528a52a"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("397aadb6-25d6-4948-97e5-e822994ab562"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("44772e5b-1cd0-4383-a577-b6fa874e6ab6"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("4cc825da-6108-4707-85a4-e7574310e5f6"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("4eb0f4c8-3bb6-4213-8cbf-9761a1c064fa"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("4eba53af-e916-4f26-acb5-0938a085c61c"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("52178fa5-abcd-4e7f-bcb2-c494b7f2ba98"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("5e2c5167-9c37-475d-b8c0-7a426e10a02e"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("60e35fe8-48c4-459d-ace4-5cc242ac6cb1"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("6471d929-92ff-4555-ad3f-7d3d57e9cb98"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("6b2385d4-2119-4b86-ba4b-ddfa0e8a3e45"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("6f878d02-9365-433a-8516-6d7b34d2541e"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("75c147aa-1076-4b76-82b8-2c62bbe52695"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("78ae0eb1-cd66-4487-a49d-38539dfdef4b"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("88c52c24-57dd-4505-b3e7-4f1e57be5afd"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("97dc3d25-d3d7-4d3b-8219-bdf23db0e5c7"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("9de9a4ae-eb7e-478f-9ef0-f119da36ba23"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("aca3e42b-2958-4a08-8bae-81a58efe8abb"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("adcf54e6-f884-4765-8829-6835eea6ace2"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("af1c538f-5c57-4c8b-9a00-39be3a1c7d69"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("c322a345-3ab5-47ea-b34a-9b0ebdfe99dc"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("cc3fc18c-c029-4811-aafd-990c8cb3e95b"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("d4b7f3e6-3671-4ebe-8d13-d7f1d065f76b"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("da346543-0244-4b83-b756-9385cd9b5e47"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("e99cd14b-af7f-42a2-b619-c3306f9e6e51"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("eccd87e1-cc0b-41a5-9fdd-e855ae1cca91"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("f296539b-772b-4aa6-8346-7e36fb6e70db"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("f9607d6b-c557-4801-81a9-b532bc9fa3d0"));

            migrationBuilder.DeleteData(
                table: "ClassMeetings",
                keyColumn: "Id",
                keyValue: new Guid("fdc4ec99-271b-457d-a867-040778b1e50a"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("323a5ad6-7c0b-4e94-b55e-0e56282d9b4f"));

            migrationBuilder.DeleteData(
                table: "UserClasses",
                keyColumn: "Id",
                keyValue: new Guid("4b500d50-f6d5-49b9-8cb8-b9dc0646ae7f"));

            migrationBuilder.DeleteData(
                table: "UserClasses",
                keyColumn: "Id",
                keyValue: new Guid("870f4bc7-7b75-44ae-9e9d-e0337693eb0e"));

            migrationBuilder.DeleteData(
                table: "UserClasses",
                keyColumn: "Id",
                keyValue: new Guid("b85a079a-fa35-4966-b8ad-4b98518e56af"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1bef51c5-000b-4555-95b9-80184c752b06"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("57b8ecbf-2475-4db1-9d36-ecc338d88445"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("7c129914-4625-46d3-b11d-3a6f122ace07"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("9a6befae-bfe1-4b01-a4fc-2805d4043df7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fb83307-3f4d-4cf7-8df0-d2dc4f8d3860"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("29bf0827-9f99-4a4b-9dd3-9b7f0d49cfa6"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("8085339c-07b6-42be-ad10-7df5eb0564ce"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("b21d2e8c-a9c9-4b25-a208-de40f2967b6d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("432d6f99-d2bf-4267-959f-1a039c950e0f"));
        }
    }
}
