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

		public IContainer Register(Type type, object instance)
		{
			_container.Register(
					Component.For(type)
						.Instance(instance)
						.Named(type.FullName)
						.LifestyleSingleton());

			return this;
		}

		public IContainer Register<TType>(object instance) where TType : class
		{
			_container.Register(
					Component.For<TType>()
						.Instance(instance as TType)
						.Named(typeof(TType).FullName)
						.LifestyleSingleton());

			return this;
		}

		public IContainer Register(object instance)
		{
			_container.Register(
					Component.For(instance.GetType())
						.Instance(instance)
						.Named(instance.GetType().FullName)
						.LifestyleSingleton());

			return this;
		}

		public IContainer Register<TType>() where TType : class, new()
		{
			var instance = new TType();

			_container.Register(
				Component.For<TType>()
					.Instance(instance)
					.Named(typeof(TType).FullName)
					.LifestyleSingleton());

			return this;
		}

		public IContainer Register<TType, TObject>()
			where TType : class
			where TObject : class, new()
		{
			var instance = new TObject() as TType;

			_container.Register(
				Component.For<TType>()
					.Instance(instance)
					.Named(typeof(TType).FullName)
					.LifestyleSingleton());

			return this;
		}

		public TType ResolveInstance<TType>() where TType : class
		{
			return _container.Resolve<TType>();
		}

		public TContainer InternalContainer<TContainer>() where TContainer : class
		{
			if (_container as TContainer == null)
				throw new InvalidCastException($"The internal container is of type {_container.GetType().FullName} and cannot be cast to {typeof(TContainer).FullName}");

			return _container as TContainer;
		}
	}
}
