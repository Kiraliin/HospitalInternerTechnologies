﻿using DataBase;
using DataBase.Repositories;
using domain.models;

namespace UnitTests;

public class DBtest
{
    private readonly ApplicationContextFactory _dbFactory;

    public DBtest()
    {
        _dbFactory = new ApplicationContextFactory();
    }

    [Fact]
    public void UserRepositoryCreate()
    {
        var context = _dbFactory.CreateDbContext();
        var repo = new UserRepository(context);
        var user = new User("Alex", "123", 1, "+79241669106", "Alexey Pak", Role.Patient);
        repo.Create(user);
        context.SaveChanges();
        Assert.True(repo.ExistLogin(user.Username));
        repo.Delete(user.Id);
        context.SaveChanges();
    }

    [Fact]
    public void UserRepositoryNotExists()
    {
        var context = _dbFactory.CreateDbContext();
        var repo = new UserRepository(context);
        var user = new User("Alex", "123", 1, "+79241669106", "Alexey Pak", Role.Patient);
        repo.Create(user);
        context.SaveChanges();
        Assert.False(repo.ExistLogin("Lana"));
        repo.Delete(user.Id);
        context.SaveChanges();
    }

    [Fact]
    public void UserRepositoryPgTest()
    {
        var context = _dbFactory.CreateDbContext();
        var repo = new UserRepository(context);

        var assertList = new List<User>();
        var user = new User("Alex", "123", 1, "+79241669106", "Alexey Pak", Role.Patient);
        assertList.Add(user);
        repo.Create(user);
        user = new User("Dima", "123", 2, "+79241669106", "Dima Pak", Role.Patient);
        assertList.Add(user);
        repo.Create(user);

        context.SaveChanges();

        var testList = repo.List().ToList();
        for (int i = 0; i < assertList.Count; ++i)
        {
            Assert.Equal(testList[i].Id, assertList[i].Id);
            Assert.Equal(testList[i].FullName, assertList[i].FullName);
            repo.Delete(testList[i].Id);
        }

        context.SaveChanges();
    }

    //[Fact]
    public void DoctorRepositoryPgTest()
    {
        var context = _dbFactory.CreateDbContext();
        var repo = new DoctorRepository(context);
        var spec = new Specialization(1, "Dentist");
        repo.Create(new Doctor(1, "Alex", spec));
        context.SaveChanges();
        var list = repo.GetBySpec(spec).ToList();
        Assert.Equal(list[0].Id, 1);
    }

    [Fact]
    public void SchenduleRepositoryPgTest()
    {
        var context = _dbFactory.CreateDbContext();
        var repo = new SchenduleRepository(context);
        var schendule = new Schendule(1, 1,
            new DateTime(2022, 12, 15, 15, 0, 0, 0),
            new DateTime(2022, 12, 15, 15, 30, 0, 0));

        repo.Create(schendule);
        context.SaveChanges();

        var spec = new Specialization(1, "Dentist");
        var test = repo.GetSchenduleByDate(new Doctor(1, "Alex", spec), new DateOnly(2022, 12, 15)).ToList()[0];

        Assert.True(test.Id == schendule.Id && test.DoctorId == schendule.DoctorId);

        repo.Delete(schendule.Id);
        context.SaveChanges();
    }
}
