using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;

namespace DependencyInjection.Infrastructure
{
	public static class TypeBroker
	{
		private static Type repoType = typeof(MemoryRepository);
		private static IRepository testRepo;

		public static IRepository Repository
		{
			get
			{
				return testRepo ?? Activator.CreateInstance(repoType) as IRepository;
			}
		}

		public static void SetRepositoryType<T>() where T : IRepository
		{
			repoType = typeof(T);
		}

		public static void SetTestObject(IRepository repo)
		{
			testRepo = repo;
		}
	}
}
