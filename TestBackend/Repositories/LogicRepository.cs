using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBackend.Models;
using TestBackend.ViewModels;

namespace TestBackend.Repositories
{
    public class LogicRepository
    {
        private readonly Database_TestContext _context;
        public LogicRepository(Database_TestContext _context)
        {
            this._context = _context;
        }
        public int InsertData(InsertDataVm trBpkb)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    TrBpkb trBpkb1 = new TrBpkb();
                    trBpkb1.AgreementNumber = trBpkb.AgreementNumber;
                    trBpkb1.BpkbDate = trBpkb.BpkbDate;
                    trBpkb1.BpkbDateIn = trBpkb.BpkbDateIn;
                    trBpkb1.BpkbNo = trBpkb.BpkbNo;
                    trBpkb1.BranchId = trBpkb.BranchId;
                    trBpkb1.FakturDate = trBpkb.FakturDate;
                    trBpkb1.FakturNo = trBpkb.FakturNo;
                    trBpkb1.LocationId = trBpkb.LocationId;
                    trBpkb1.PoliceNo = trBpkb.PoliceNo;

                    var result = _context.TrBpkbs.Add(trBpkb1);
                    _context.SaveChanges();

                    transaction.Commit();
                    return 1;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return 0;
                }
            }
        }

        public List<MsStorageLocation> GetUser()
        {
            var data = _context.MsStorageLocations.ToList();
            return data.ToList();
        }
    }
}
