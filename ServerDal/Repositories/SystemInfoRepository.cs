using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerDal.Models;

namespace ServerDal.Repositories
{
    public class SystemInfoRepository : IRepository<SystemInfo>
    {
        private ApplicationContext Context;
        public SystemInfoRepository()
        {
            this.Context = new ApplicationContext();
        }
        public void Add(SystemInfo entity)
        {
            this.Context.SystemInfos.Add(entity);
            this.Context.SaveChanges();
        }

        public void Delete(SystemInfo entity)
        {
            
            this.Context.SystemInfos.Remove(entity);
            this.Context.SaveChanges();
        }

        public SystemInfo Get(int id)
        {
            return this.Context.SystemInfos.Find(id);
        }
        public SystemInfo GetByIp(string ip)
        {
            return this.Context.SystemInfos.FirstOrDefault(x=>x.Ip==ip);
        }

        public IEnumerable<SystemInfo> GetAll()
        {
            return this.Context.SystemInfos;
        }
    }
}
