using Safety_app.Data.DatabaseOperation.ModeldatabaseOperations;
using SQLite;

namespace Safety_app.Data.DatabaseOperation
{
    public class DataContext
    {
        private SQLiteAsyncConnection _database;
        public static PrescriptionOperator prescriptionOperator { get; set; }
        public static ScheduleOperator ScheduleOperator { get; set; }
        public static DrugOperator DrugOperator { get; set; }
        public static DrugSchedulePrescriptionOperator DrugSchedulePrescriptionOperator { get; set; }

        public DataContext(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            SetDatabaseOnObjects();
        }


        private void SetDatabaseOnObjects()
        {
            prescriptionOperator = new PrescriptionOperator(ref _database);
            ScheduleOperator = new ScheduleOperator(ref _database);
            DrugOperator = new DrugOperator(ref _database);
            DrugSchedulePrescriptionOperator = new DrugSchedulePrescriptionOperator(ref _database);
        }
        public PrescriptionOperator GetPrescriptionOperator()
        {
            return prescriptionOperator;
        }
        public ScheduleOperator GetScheduleOperator()
        {
            return ScheduleOperator;
        }
        public DrugOperator GetDrugOperator()
        {
            return DrugOperator;
        }
        public DrugSchedulePrescriptionOperator GetDrugSchedulePrescriptionOperator()
        {
            return DrugSchedulePrescriptionOperator;
        }
        public SQLiteAsyncConnection GetDatabase()
        {
            return _database;
        }
    }
}
