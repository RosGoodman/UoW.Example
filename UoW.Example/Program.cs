using SciMaterials.Data.UnitOfWork;
using UoW.Example.DAL.Context;
using UoW.Example.Usage;

var context = new ContextDb();
var uow = new UnitOfWork(context);

var usingUoW = new ClassUsingUoW(uow);
usingUoW.SomeMethodOne();