﻿using Shouldly;
using Xunit;

namespace DbfDataReader.Tests
{
    [Collection("dbase_03")]
    public class Dbase03NullCharTests : DbaseTests
    {
        private const string Dbase03FixturePath = "../../../../fixtures/dbase_03_nullchar.dbf";

        public Dbase03NullCharTests() : base(Dbase03FixturePath)
        {
        }

        [Fact]
        public void Should_report_correct_record_count()
        {
            DbfHeader.RecordCount.ShouldBe(3);
        }

        [Fact]
        public void Should_report_correct_version_number()
        {
            DbfHeader.Version.ShouldBe(0x03);
        }

        [Fact]
        public void Should_report_that_the_file_is_not_foxpro()
        {
            DbfHeader.IsFoxPro.ShouldBeFalse();
        }

        [Fact]
        public void Should_have_the_correct_number_of_columns()
        {
            DbfTable.Columns.Count.ShouldBe(2);
        }

        [Fact]
        public void Should_have_the_correct_column_schema()
        {
            ValidateColumnSchema("../../../../fixtures/dbase_03_nullchar_summary.txt");
        }

        [Fact]
        [UseCulture("it-IT")]
        public void Should_have_correct_row_values()
        {
            ValidateRowValues("../../../../fixtures/dbase_03_nullchar.csv");
        }
    }
}
