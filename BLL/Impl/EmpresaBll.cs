using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using Servicos;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public class EmpresaBll : IEmpresaBll
    {
        private IEmpresaDal _empresaDal;
        public EmpresaBll()
        {
            _empresaDal = new EmpresaDal();
        }
        public async Task Atualizar(Empresa empresa)
        {
            if(null != empresa)
            {
                if (empresa.Endereco != null)
                {
                    GoogleMaps googleMaps = new GoogleMaps();

                    dynamic retorno = await googleMaps.GetLatitudeLongitude(empresa.Endereco);

                    if (retorno.status == "OK")
                    {
                        foreach (var data in retorno.results)
                        {
                            empresa.Latitute = data.geometry.location.lat;
                            empresa.Longitude = data.geometry.location.lng;
                        }
                    }
                }

                _empresaDal.Update(empresa);
                _empresaDal.SaveChanges();
            }
        }

        public void AtualizarSkin(Empresa empresa)
        {
            _empresaDal.Update(empresa);
            _empresaDal.SaveChanges();
        }

        public void Excluir(Empresa empresa)
        {
            if (null != empresa)
            {
                _empresaDal.Delete(empresa);
                _empresaDal.SaveChanges();
            }
        }

        public IQueryable<Empresa> Listar()
        {
            return _empresaDal.GetAll();
        }

        public Empresa Obter(int id)
        {
            return _empresaDal.Find(e => e.Id == id);
        }

        public void Salvar(Empresa empresa)
        {
            if (null != empresa)
            {
                _empresaDal.Add(empresa);
                _empresaDal.SaveChanges();
            }
        }
    }
}
