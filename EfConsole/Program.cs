using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using EdDbEfLib.Controllers;
using EdDbEfLib.Models;

namespace EfConsole {

    class Program {

        public static async Task Main(string[] args) {
            await TestStudentsController();
        }
        public async static Task TestStudentsController() {
            var ctrl = new StudentsController();

            var s = new Student() {
                Id = 0, Firstname = "X", Lastname = "X", Gpa = 2.0m, Sat = 1000, MajorId = null
            };
            var s2 = await ctrl.Insert(s);
            s2.Lastname = "XXX";
            await ctrl.Update(s2.Id, s2);
            await ctrl.Delete(s2.Id);

        }
        public async static Task TestMajorsController() {

            var majorCtrl = new MajorsController();
            //var majors = await majorCtrl.GetAll();
            var medMajor = await majorCtrl.GetByPk(1);
            //var major = new Major() {
            //    Id = 0, Code = "MEDS", Description = "Medical", MinSat = 1200
            //};
            //var result = await majorCtrl.Insert(major);
            //mathMajor.Description = "Medicine";
            //var result = await majorCtrl.Update(mathMajor.Id, mathMajor);
            //var result = await majorCtrl.Delete(medMajor.Id);
        }
    }
}
