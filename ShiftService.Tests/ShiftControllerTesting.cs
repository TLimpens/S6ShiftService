using Common.DataTransfer.Shift;
using S = ShiftService.Models.Shift;
using U = ShiftService.Models.User;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ShiftService.Business.Shifts;
using ShiftService.Context;
using ShiftService.Controllers;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Common.DataTransfer;

namespace ShiftService.Tests
{
    public class ShiftControllerTesting
    {
        private ShiftController shiftController;
        private ShiftManager shiftManager;
        private ShiftContext shiftContext;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ShiftContext>()
            .UseInMemoryDatabase(databaseName: "ShifttDatabase")
            .Options;

            // Insert seed data into the database using one instance of the context
            shiftContext = new ShiftContext(options);
            shiftContext.Shifts.Add(new Shift { id = 1, employeeSlots = 6, shiftDate = DateTime.Now, workingEmployees = new List<User>() { new User(1, "Dave", 1), new User(2, "Steve", 1) } });
            shiftContext.Shifts.Add(new Shift { id = 2, employeeSlots = 6, shiftDate = DateTime.Now, workingEmployees = new List<User>() { new User(1, "Dave", 2), new User(2, "Steve", 2), new User(3, "Lisa", 2) } });
            shiftContext.Shifts.Add(new Shift { id = 3, employeeSlots = 6, shiftDate = DateTime.Now, workingEmployees = new List<User>() });
            shiftContext.SaveChanges();

            shiftManager = new ShiftManager(shiftContext);

            shiftController = new ShiftController(shiftManager);
        }

        [Test]
        public async Task getShiftTest()
        {
            var shift = await shiftController.GetShift(1);

            shift.Should().NotBeNull();
            shift.id.Should().Be(1);
            shift.GetType().Should().Be(typeof(S));
        }

        [Test]
        public async Task getShiftsTest()
        {
            var shift = await shiftController.GetShifts();

            shift.Should().NotBeNull();
            shift.Count.Should().Be(3);
            shift.GetType().Should().Be(typeof(List<S>));
        }

        [Test]
        public async Task getShiftsForUserTest()
        {
            var shift = await shiftController.GetShiftsForUser(2);

            shift.Should().NotBeNull();
            shift.Count.Should().Be(2);
            shift.GetType().Should().Be(typeof(List<S>));
        }

        [Test]
        public async Task postNewShift()
        {
            shiftController.PostNewShift(new S(9, 4, DateTime.Now, new List<U>() { new U(1, "Dave"), new U(2, "Steve"), new U(3, "Lisa") } ));

            var shift = await shiftController.GetShift(9);

            shift.Should().NotBeNull();
            shift.id.Should().Be(9);
            shift.GetType().Should().Be(typeof(S));
        }

        [OneTimeTearDown]
        public void teardown()
        {
            shiftContext.Dispose();
            shiftController.Dispose();
        }
    }
}
