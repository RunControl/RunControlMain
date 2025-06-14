using UnityEngine;
using Batu;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;
public class MarketManager : MonoBehaviour, IStoreListener
{

    private IStoreController m_storeController;
    private static IExtensionProvider m_ExtensionProvider;
    BellekYonetim _bellekYonetim = new BellekYonetim();
    VeriYönetimi _veriYönetimi = new VeriYönetimi();

    // Uygulama markette oluþtrulduktan sonra ID ler doldurulmalý!!!
    private static string Puan_250 = "";
    private static string Puan_500 = "";
    private static string Puan_750 = "";
    private static string Puan_1000 = "";

    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();
    public List<DilVerileriAnaObje> _DilVerileriOkunan = new List<DilVerileriAnaObje>();
    public TextMeshProUGUI[] textObjeleri;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _veriYönetimi.Dil_Load();
        _DilVerileriOkunan = _veriYönetimi.DilListeyiAktar();
        _DilVerileriAnaObje.Add(_DilVerileriOkunan[3]);
        DilTercihiYönetimi();

        if(m_storeController == null)
        {
            InitializePurchasing();
        }
    }

    public void GeriDon()
    {
        SceneManager.LoadScene(0);
    }

    public void InitializePurchasing()
    {
        if(IsInitialized())
        {
            return;
        }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(Puan_250, ProductType.Consumable);
        builder.AddProduct(Puan_500, ProductType.Consumable);
        builder.AddProduct(Puan_750, ProductType.Consumable);
        builder.AddProduct(Puan_1000, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void UrunAl(string UrunAdi)
    {
      BuyProductId(UrunAdi);
    }

    public void BuyProductId(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_storeController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                m_storeController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("Satýn alýrken hata oluþtu");
            }
        }
        else
        {
            Debug.Log("Ürün çaðýrýlamýyor");
        }
    }

    private bool IsInitialized()
    {
        // If we haven't set up the Unity Purchasing reference
        return m_storeController != null && m_ExtensionProvider != null;
    }

    public void DilTercihiYönetimi()
    {
        if (_bellekYonetim.VeriOku<string>("Dil") == "TR")
        {

            for (int i = 0; i < textObjeleri.Length; i++)
            {
                textObjeleri[i].text = _DilVerileriAnaObje[0].DilVerileri_TR[i].Metin;
            }
        }
        else
        {

            for (int i = 0; i < textObjeleri.Length; i++)
            {
                textObjeleri[i].text = _DilVerileriAnaObje[0].DilVerileri_EN[i].Metin;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        throw new System.NotImplementedException();
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        throw new System.NotImplementedException();
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
       if(string.Equals(purchaseEvent.purchasedProduct.definition.id, Puan_250, System.StringComparison.Ordinal))
        {
            _bellekYonetim.VeriKaydet("Puan", _bellekYonetim.VeriOku<int>("Puan") + 250);

            // Handle the purchase of 250 points
            Debug.Log("250 Puan satýn alýndý");
        }
        else if (string.Equals(purchaseEvent.purchasedProduct.definition.id, Puan_500, System.StringComparison.Ordinal))
        {

            _bellekYonetim.VeriKaydet("Puan", _bellekYonetim.VeriOku<int>("Puan") + 500);

            // Handle the purchase of 500 points
            Debug.Log("500 Puan satýn alýndý");
        }
        else if (string.Equals(purchaseEvent.purchasedProduct.definition.id, Puan_750, System.StringComparison.Ordinal))
        {
            _bellekYonetim.VeriKaydet("Puan", _bellekYonetim.VeriOku<int>("Puan") + 750);

            // Handle the purchase of 750 points
            Debug.Log("750 Puan satýn alýndý");
        }
        else if (string.Equals(purchaseEvent.purchasedProduct.definition.id, Puan_1000, System.StringComparison.Ordinal))
        {
            _bellekYonetim.VeriKaydet("Puan", _bellekYonetim.VeriOku<int>("Puan") + 1000);

            // Handle the purchase of 1000 points
            Debug.Log("1000 Puan satýn alýndý");
        }
        else
        {
            Debug.Log("Satýn alma iþlemi bilinmeyen ürünle sonuçlandý: " + purchaseEvent.purchasedProduct.definition.id);
        }
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        throw new System.NotImplementedException();
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        m_storeController = controller;
        m_ExtensionProvider = extensions;
    }
}
