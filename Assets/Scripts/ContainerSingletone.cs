using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;
using UnityDI;

namespace Assets.Scripts
{
    public static class ContainerSingletone
    {
        private static Container _container;
		private static object lockedObject=new object();


		
		public static Container Container
        {
            get
            {
				if(_container==null)
				{
				lock(lockedObject){
					var installer = new ContainerInstaller();
					_container = installer.Install();
					}
				}
                return _container;


            }
        }
    }
}

