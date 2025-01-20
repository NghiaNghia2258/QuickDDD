using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MajorSubject",
                columns: new[] { "MajorsId", "SubjectsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 8, 1 },
                    { 8, 2 },
                    { 8, 3 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Code", "DeletedAt", "DeletedBy", "DeletedName", "ExerciseCredits", "IsDeleted", "IsIncludedInGPA", "IsMandatory", "Name", "PracticeCredits", "Semester", "TheoryCredits", "Version" },
                values: new object[,]
                {
                    { 4, "HDC", null, null, null, 0, false, false, false, "Hóa học đại cương", 0, 0, 0, 0 },
                    { 5, "TML", null, null, null, 0, false, false, false, "Triết học Mác - Lênin", 0, 0, 0, 0 },
                    { 6, "KTML", null, null, null, 0, false, false, false, "Kinh tế chính trị Mác - Lênin", 0, 0, 0, 0 },
                    { 7, "GDQP", null, null, null, 0, false, false, false, "Giáo dục quốc phòng - an ninh", 0, 0, 0, 0 },
                    { 8, "GDTC", null, null, null, 0, false, false, false, "Giáo dục thể chất", 0, 0, 0, 0 },
                    { 9, "KNM", null, null, null, 0, false, false, false, "Kỹ năng mềm", 0, 0, 0, 0 },
                    { 10, "TACB", null, null, null, 0, false, false, false, "Tiếng Anh cơ bản", 0, 0, 0, 0 },
                    { 11, "LLCT", null, null, null, 0, false, false, false, "Lý luận chính trị", 0, 0, 0, 0 },
                    { 12, "VHDG", null, null, null, 0, false, false, false, "Văn hóa đại cương", 0, 0, 0, 0 },
                    { 13, "TDK", null, null, null, 0, false, false, false, "Tư duy khoa học", 0, 0, 0, 0 },
                    { 14, "CSDLTG", null, null, null, 0, false, false, false, "Cấu trúc dữ liệu và giải thuật", 0, 0, 0, 0 },
                    { 15, "HOC", null, null, null, 0, false, false, false, "Học máy", 0, 0, 0, 0 },
                    { 16, "KHMT", null, null, null, 0, false, false, false, "Kỹ thuật lập trình", 0, 0, 0, 0 },
                    { 17, "CS", null, null, null, 0, false, false, false, "Cơ sở dữ liệu", 0, 0, 0, 0 },
                    { 18, "TNSP", null, null, null, 0, false, false, false, "Tin học và hệ thống phần mềm", 0, 0, 0, 0 },
                    { 19, "HTH", null, null, null, 0, false, false, false, "Hệ thống thông tin", 0, 0, 0, 0 },
                    { 20, "ATTT", null, null, null, 0, false, false, false, "An toàn thông tin", 0, 0, 0, 0 },
                    { 21, "MTT", null, null, null, 0, false, false, false, "Mạng máy tính", 0, 0, 0, 0 },
                    { 22, "PTUD", null, null, null, 0, false, false, false, "Phát triển ứng dụng di động", 0, 0, 0, 0 },
                    { 23, "CC", null, null, null, 0, false, false, false, "Công cụ lập trình", 0, 0, 0, 0 },
                    { 24, "QLDJPM", null, null, null, 0, false, false, false, "Quản lý dự án phần mềm", 0, 0, 0, 0 },
                    { 25, "KTPM", null, null, null, 0, false, false, false, "Kiểm thử phần mềm", 0, 0, 0, 0 },
                    { 26, "LTPM", null, null, null, 0, false, false, false, "Lập trình mạng", 0, 0, 0, 0 },
                    { 27, "LPCT", null, null, null, 0, false, false, false, "Lập trình C++", 0, 0, 0, 0 },
                    { 28, "LTPY", null, null, null, 0, false, false, false, "Lập trình Python", 0, 0, 0, 0 },
                    { 29, "HTD", null, null, null, 0, false, false, false, "Hệ thống điều khiển", 0, 0, 0, 0 },
                    { 30, "TDTH", null, null, null, 0, false, false, false, "Thiết kế hệ thống điện tự động", 0, 0, 0, 0 },
                    { 31, "DTHD", null, null, null, 0, false, false, false, "Điện tử công nghiệp", 0, 0, 0, 0 },
                    { 32, "HTDC", null, null, null, 0, false, false, false, "Hệ thống điện công nghiệp", 0, 0, 0, 0 },
                    { 33, "TDCN", null, null, null, 0, false, false, false, "Thiết kế điện công nghiệp", 0, 0, 0, 0 },
                    { 34, "CVDH", null, null, null, 0, false, false, false, "Cấu trúc và vận hành của mạng điện", 0, 0, 0, 0 },
                    { 35, "QLNGE", null, null, null, 0, false, false, false, "Quản lý năng lượng và hiệu suất", 0, 0, 0, 0 },
                    { 36, "KTDCD", null, null, null, 0, false, false, false, "Kỹ thuật điều khiển điện", 0, 0, 0, 0 },
                    { 37, "CHVL", null, null, null, 0, false, false, false, "Cơ học vật liệu", 0, 0, 0, 0 },
                    { 38, "PAUBD", null, null, null, 0, false, false, false, "Phân tích ứng suất và biến dạng", 0, 0, 0, 0 },
                    { 39, "TKKC", null, null, null, 0, false, false, false, "Tính toán kết cấu", 0, 0, 0, 0 },
                    { 40, "CHVR", null, null, null, 0, false, false, false, "Cơ học vật rắn", 0, 0, 0, 0 },
                    { 41, "CHPH", null, null, null, 0, false, false, false, "Cơ học phá hủy", 0, 0, 0, 0 },
                    { 42, "CHCL", null, null, null, 0, false, false, false, "Cơ học chất lưu", 0, 0, 0, 0 },
                    { 43, "DLDVT", null, null, null, 0, false, false, false, "Động lực học của vật thể", 0, 0, 0, 0 },
                    { 44, "KTKDH", null, null, null, 0, false, false, false, "Kỹ thuật khí động học", 0, 0, 0, 0 },
                    { 45, "KCBTCT", null, null, null, 0, false, false, false, "Kết cấu bê tông cốt thép", 0, 0, 0, 0 },
                    { 46, "KTTK", null, null, null, 0, false, false, false, "Kỹ thuật thi công", 0, 0, 0, 0 },
                    { 47, "QLDX", null, null, null, 0, false, false, false, "Quản lý dự án xây dựng", 0, 0, 0, 0 },
                    { 48, "KTVTXD", null, null, null, 0, false, false, false, "Kỹ thuật vật liệu xây dựng", 0, 0, 0, 0 },
                    { 49, "KHVL", null, null, null, 0, false, false, false, "Khoa học vật liệu", 0, 0, 0, 0 },
                    { 50, "KTVLCT", null, null, null, 0, false, false, false, "Kỹ thuật vật liệu composite", 0, 0, 0, 0 },
                    { 51, "VTXD", null, null, null, 0, false, false, false, "Vật liệu xây dựng", 0, 0, 0, 0 },
                    { 52, "CTXLVL", null, null, null, 0, false, false, false, "Công nghệ xử lý vật liệu", 0, 0, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "MajorSubject",
                columns: new[] { "MajorsId", "SubjectsId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 15 },
                    { 1, 16 },
                    { 1, 17 },
                    { 1, 18 },
                    { 1, 19 },
                    { 1, 20 },
                    { 1, 21 },
                    { 1, 22 },
                    { 1, 23 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 11 },
                    { 2, 12 },
                    { 2, 13 },
                    { 2, 14 },
                    { 2, 15 },
                    { 2, 16 },
                    { 2, 17 },
                    { 2, 18 },
                    { 2, 19 },
                    { 2, 20 },
                    { 2, 21 },
                    { 2, 22 },
                    { 2, 23 },
                    { 2, 24 },
                    { 2, 25 },
                    { 2, 26 },
                    { 2, 27 },
                    { 2, 28 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 29 },
                    { 3, 30 },
                    { 3, 31 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 32 },
                    { 4, 33 },
                    { 4, 34 },
                    { 4, 35 },
                    { 4, 36 },
                    { 5, 4 },
                    { 5, 37 },
                    { 5, 38 },
                    { 5, 39 },
                    { 5, 40 },
                    { 5, 41 },
                    { 6, 4 },
                    { 6, 5 },
                    { 6, 6 },
                    { 6, 7 },
                    { 6, 8 },
                    { 6, 9 },
                    { 6, 42 },
                    { 6, 43 },
                    { 6, 44 },
                    { 7, 4 },
                    { 7, 45 },
                    { 7, 46 },
                    { 7, 47 },
                    { 7, 48 },
                    { 8, 48 },
                    { 8, 49 },
                    { 8, 50 },
                    { 8, 51 },
                    { 8, 52 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 15 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 17 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 18 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 19 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 21 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 22 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 1, 23 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 16 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 17 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 18 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 19 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 20 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 21 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 22 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 23 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 24 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 25 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 26 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 27 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 2, 28 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 3, 29 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 3, 30 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 3, 31 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 4, 32 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 4, 33 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 4, 34 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 4, 35 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 4, 36 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 5, 37 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 5, 38 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 5, 39 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 5, 40 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 5, 41 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 6, 42 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 6, 43 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 6, 44 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 7, 45 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 7, 46 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 7, 47 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 7, 48 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 8, 48 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 8, 49 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 8, 50 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 8, 51 });

            migrationBuilder.DeleteData(
                table: "MajorSubject",
                keyColumns: new[] { "MajorsId", "SubjectsId" },
                keyValues: new object[] { 8, 52 });

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 52);
        }
    }
}
