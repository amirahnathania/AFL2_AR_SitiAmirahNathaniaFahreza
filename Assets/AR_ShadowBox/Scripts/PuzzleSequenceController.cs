
using UnityEngine;
using Vuforia;

public class PuzzleSequenceController : MonoBehaviour
{
    [Header("Animasi Puzzle")]
    public Animator bagianAtas;
    public Animator bagianTengah;
    public Animator bagianBawah;

    [Header("Animasi Karakter Tengah")]
    public Animator karakterPopOut;

    [Header("Animasi Label")]
    public Animator labelVericho;

    [Header("Animasi Disney")]
    public Animator lampuAladin;
    public Animator pooh;
    public Animator pinocchio;
    public Animator sepatuCinderella;
    public Animator mickeyMouse;
    public Animator fairyGodmother;
    public Animator poisonApple;
    public Animator baymax;
    public Animator tangled;
    public Animator nemo;


    private ObserverBehaviour target;
    private bool sedangTerdeteksi = false;

    void Awake()
    {
        target = GetComponent<ObserverBehaviour>();

        if (target == null)
        {
            Debug.LogError(
                "Pasang PuzzleSequenceController pada Gambar1!"
            );

            enabled = false;
            return;
        }

        // Siapkan semua animasi pada frame awal.
        // Animator tidak berjalan sebelum target ditemukan.
        SiapkanSemua();
    }

    void OnEnable()
    {
        if (target != null)
        {
            target.OnTargetStatusChanged += StatusBerubah;
        }
    }

    void Start()
    {
        if (target != null)
        {
            PeriksaStatus(target.TargetStatus);
        }
    }

    void OnDisable()
    {
        if (target != null)
        {
            target.OnTargetStatusChanged -= StatusBerubah;
        }
    }

    void StatusBerubah(
        ObserverBehaviour observer,
        TargetStatus status)
    {
        PeriksaStatus(status);
    }

    void PeriksaStatus(TargetStatus status)
    {
        // Hanya terima tracking normal.
        bool ditemukan =
            status.Status == Status.TRACKED &&
            status.StatusInfo == StatusInfo.NORMAL;

        // Jangan ulang animasi selama target tetap terdeteksi.
        if (ditemukan == sedangTerdeteksi)
        {
            return;
        }

        sedangTerdeteksi = ditemukan;

        if (sedangTerdeteksi)
        {
            Debug.Log(
                "Miniatur ditemukan! Semua animasi dimulai."
            );

            // =================================
            // 1. ANIMASI PUZZLE
            // =================================

            Mainkan(bagianAtas, "Puzzle_BagianAtas");
            Mainkan(bagianTengah, "Puzzle_BagianTengah");
            Mainkan(bagianBawah, "Puzzle_BagianBawah");

            // =================================
            // 2. ANIMASI KARAKTER TENGAH
            // =================================

            Mainkan(karakterPopOut, "Karakter_PopOut");

            // =================================
            // 3. ANIMASI LABEL
            // =================================

            Mainkan(labelVericho, "Label_PopUp");

            // =================================
            // 4. ANIMASI LAMPU ALADDIN
            // =================================

            // PopOut dimulai dari Frame 0.
            // Frame 0-60 harus transparan.
            // Setelah Frame 60, lampu mulai muncul.
            // Transisi ke Float diatur oleh Animator Controller.

            if (lampuAladin != null)
            {
                Mainkan(lampuAladin, "LampuAladin_PopOut"
                );
            }

            if (pooh != null)
            {
                Mainkan(pooh, "Pooh_PopOut");
            }

            if (pinocchio != null)
            {
                Mainkan(pinocchio, "Pinocchio_PopOut");
            }

            if (sepatuCinderella != null)
            {
                Mainkan(sepatuCinderella, "SepatuCinderella_PopOut");
            }

            if (mickeyMouse != null)
            {
                Mainkan(mickeyMouse, "MickeyMouse_PopOut");
            }

            if (fairyGodmother != null)
            {
                Mainkan(fairyGodmother, "FairyGodmother_PopOut");
            }

            if (fairyGodmother != null)
            {
                Mainkan(poisonApple, "PoisonApple_PopOut");
            }

            if (fairyGodmother != null)
            {
                Mainkan(baymax, "Baymax_PopOut");
            }

            if (fairyGodmother != null)
            {
               Mainkan(tangled, "Tangled_PopOut");
            }

            if (fairyGodmother != null)
            {
               Mainkan(nemo, "Nemo_PopOut");
            }
        }
        else
        {
            Debug.Log(
                "Miniatur hilang. Animasi disiapkan untuk scan ulang."
            );

            // Semua Animator kembali ke frame awal.
            SiapkanSemua();
        }
    }

    void SiapkanSemua()
    {
        // Puzzle
        Siapkan(bagianAtas, "Puzzle_BagianAtas");
        Siapkan(bagianTengah, "Puzzle_BagianTengah");
        Siapkan(bagianBawah, "Puzzle_BagianBawah");

        // Karakter tengah
        Siapkan(karakterPopOut, "Karakter_PopOut");

        // Label
        Siapkan(labelVericho, "Label_PopUp");

        // Disney
        if (lampuAladin != null)
        {
            Siapkan(lampuAladin, "LampuAladin_PopOut");
        }

        if (pooh != null)
        {
            Siapkan(pooh, "Pooh_PopOut");
        }

        if (pinocchio != null)
        {
            Siapkan(pinocchio, "Pinocchio_PopOut");
        }

        if (sepatuCinderella != null)
        {
            Siapkan(sepatuCinderella, "SepatuCinderella_PopOut");
        }

        if (mickeyMouse != null)
        {
            Siapkan(mickeyMouse, "MickeyMouse_PopOut");
        }

        if (fairyGodmother != null)
        {
            Siapkan(fairyGodmother, "FairyGodmother_PopOut");
        }

        if (fairyGodmother != null)
        {
            Siapkan(poisonApple, "PoisonApple_PopOut");
        }

        if (fairyGodmother != null)
        {
            Siapkan(baymax, "Baymax_PopOut");
        }

        if (fairyGodmother != null)
        {
            Siapkan(tangled, "Tangled_PopOut");
        }

        if (fairyGodmother != null)
        {
            Siapkan(nemo, "Nemo_PopOut");
        }
    }

    bool CekAnimator(Animator anim, string namaState)
    {
        if (anim == null)
        {
            Debug.LogWarning(
                "Animator belum dihubungkan: " + namaState
            );

            return false;
        }

        if (anim.runtimeAnimatorController == null)
        {
            Debug.LogWarning(
                "Animator Controller belum ada: " + namaState
            );

            return false;
        }

        string state = "Base Layer." + namaState;

        if (!anim.HasState(
            0,
            Animator.StringToHash(state)))
        {
            Debug.LogWarning(
                "State tidak ditemukan: " + state
            );

            return false;
        }

        return true;
    }

    void Siapkan(Animator anim, string namaState)
    {
        if (!CekAnimator(anim, namaState))
        {
            return;
        }

        string state = "Base Layer." + namaState;

        // Posisikan Animator pada frame 0 dan hentikan.
        anim.enabled = true;
        anim.speed = 0f;

        anim.Play(state, 0, 0f);
        anim.Update(0f);
    }

    void Mainkan(Animator anim, string namaState)
    {
        if (!CekAnimator(anim, namaState))
        {
            return;
        }

        string state = "Base Layer." + namaState;

        // Selalu mulai dari awal animasi.
        anim.enabled = true;
        anim.speed = 0f;

        anim.Play(state, 0, 0f);
        anim.Update(0f);

        // Jalankan animasi.
        anim.speed = 1f;
    }
}
