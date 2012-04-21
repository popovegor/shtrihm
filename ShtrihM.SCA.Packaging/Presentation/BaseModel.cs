using ShtrihM.SCA.Packaging.Domain.Entities;
using ShtrihM.SCA.Packaging.Domain.Helpers;
using ShtrihM.SCA.Packaging.Domain.Exceptions;
using ShtrihM.SCA.Packaging.Localization;

namespace ShtrihM.SCA.Packaging.Presentation
{
  public abstract class BaseModel
  {
    public UserEntity User { get; set; }

    public BaseModel(UserEntity user)
    {
      if(user == null)
      {
        throw new ExternalException(Msgs.user_is_not_defined);
      }
      User = user;
    }
    
    public virtual bool IsValid()
    {
      bool valid = User != null && User.Id > 0;
      if (valid == false)
      {
        throw new ExternalException(Msgs.user_is_not_defined);
      }
      return valid;
    }
  }
}
