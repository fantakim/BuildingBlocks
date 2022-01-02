﻿using Autofac;
using FluentValidation;
using Loom.BuildingBlocks.Mediatr.Commands;
using Loom.BuildingBlocks.Mediatr.Validators;
using MediatR;
using System.Reflection;
using Module = Autofac.Module;

namespace Loom.BuildingBlocks.Mediatr.Autofac
{
    public class MediatrModule : Module
    {
        private readonly Assembly _applicationAssembly;

        private MediatrModule(Assembly applicationAssembly)
        {
            _applicationAssembly = applicationAssembly;
        }

        public static MediatrModule Create(Assembly applicationAssembly)
            => new MediatrModule(applicationAssembly);

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(_applicationAssembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            var handlers = _applicationAssembly.GetTypes()
                .Where(t => t.IsClosedTypeOf(typeof(IRequestHandler<,>)))
                .ToList();

            handlers.ForEach(t =>
            {
                var localHandlers = t.GetInterfaces()
                    .Where(@interface => @interface.IsClosedTypeOf(typeof(IRequestHandler<,>)));

                foreach (var localHandler in localHandlers)
                {
                    var implementation = typeof(IdentifiedCommandHandler<,>)
                        .MakeGenericType(localHandler.GenericTypeArguments);

                    var arg0 = typeof(IdentifiedCommand<,>)
                        .MakeGenericType(localHandler.GenericTypeArguments);
                    var arg1 = localHandler.GenericTypeArguments[1];

                    var service = typeof(IRequestHandler<,>)
                        .MakeGenericType(arg0, arg1);

                    builder.RegisterType(implementation).As(service);
                }
            });

            var sharedLogicMediatr = typeof(IdentifiedCommand<,>).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(sharedLogicMediatr)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder
                .RegisterAssemblyTypes(sharedLogicMediatr)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(_applicationAssembly)
                .AsClosedTypesOf(typeof(IValidator<>));

            builder.Register<SingleInstanceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t =>
                {
                    return componentContext.TryResolve(t, out var o) ? o : null;
                };
            });

            builder.Register<MultiInstanceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();

                return t =>
                {
                    var resolved = (IEnumerable<object>)componentContext.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
                    return resolved;
                };
            });

            builder.RegisterGeneric(typeof(ValidatorsBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
