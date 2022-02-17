using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Remnant.Dependency.Interface;
using System;

namespace Remnant.Dependency.CastleWindsor
{
	public class CastleAdapter : IContainer
	{
		private readonly IWindsorContainer _container;

		public CastleAdapter(IWindsorContainer container)
		{
			if (container == null)
				throw new ArgumentNullException(nameof(container));

			_container = container;
		}

		public IContainer Clear()
		{
			throw new NotSupportedException("Castle Windsor does not support 'Clear'.");
		}

		public IContainer DeRegister<TType>() where TType : class
		{
			var instance = _container.Resolve<TType>();
			_container.Release(instance);
			return this;
		}

		public IContainer DeRegister(object instance)
		{
			_container.Release(instance);
			return this;
		}

		public IContainer Register<TType>(TType instance) where TType : class
		{
			_container.Register(Component.For<TType>().Instance(instance));
			return this;
		}

		public IContainer Register(object instance)
		{
			_container.Register(Component.For().Instance(instance));
			return this;
		}

		public IContainer Register<TType>() where TType : class, new()
		{
			_container.Register(Component.For<TType>().Instance(new TType()));
			return this;
		}

		public IContainer Register<TType, TObject>()
			where TType : class
			where TObject : class, new()
		{
			_container.Register(Component.For<TType>().Instance(new Object() as TType));
			return this;
		}

		public TType ResolveInstance<TType>() where TType : class
		{
			return _container.Resolve<TType>();
		}
	}
}
