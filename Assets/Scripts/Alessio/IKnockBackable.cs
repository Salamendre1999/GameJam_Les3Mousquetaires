using System.Collections;

namespace Alessio
{
    public interface IKnockBackable
    {
        void KnockBackHandler();
    
        IEnumerator CancelKnockBack();
    }
}
