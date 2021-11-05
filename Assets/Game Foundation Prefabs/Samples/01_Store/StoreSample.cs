using System;
using UnityEngine.GameFoundation.DefaultLayers;

namespace UnityEngine.GameFoundation.Sample
{
    public class StoreSample : PrefabSample
    {
        /// <summary>
        ///     The prefab to show wait animation when Transaction is in progress
        /// </summary>
        public GameObject waitAnimationPrefab;
        
        /// <summary>
        ///     The Transform to keep the reference of wait animation
        /// </summary>
        private Transform m_WaitAnimation;

        /// <summary>
        ///     Standard starting point for Unity scripts.
        /// </summary>
        void Start()
        {
            // Check if the Sample Project database has been properly setup
            if (!VerifyDatabase())
            {
                wrongDatabasePanel.SetActive(true);
            }
        }
        
        private void OnEnable()
        {
            GameFoundationSdk.initialized += RegisterEvents;
            GameFoundationSdk.uninitialized += UnregisterEvents;
            
            if (GameFoundationSdk.IsInitialized)
            {
                RegisterEvents();   
            }
        }
        
        private void OnDisable()
        {
            GameFoundationSdk.initialized -= RegisterEvents;
            GameFoundationSdk.uninitialized -= UnregisterEvents;

            if (GameFoundationSdk.IsInitialized)
            {
                UnregisterEvents();   
            }
        }
        
        /// <summary>
        ///     Add necessary events for this sample to Game Foundation.
        /// </summary>
        void RegisterEvents()
        {
            GameFoundationSdk.transactions.transactionInitiated += OnTransactionInitiated;
            GameFoundationSdk.transactions.transactionSucceeded += OnTransactionSucceeded;
            GameFoundationSdk.transactions.transactionFailed += OnTransactionFailed;
        }

        /// <summary>
        ///     Removes the events for this sample from Game Foundation.
        /// </summary>
        void UnregisterEvents()
        {
            GameFoundationSdk.transactions.transactionInitiated -= OnTransactionInitiated;
            GameFoundationSdk.transactions.transactionSucceeded -= OnTransactionSucceeded;
            GameFoundationSdk.transactions.transactionFailed -= OnTransactionFailed;
        }
        
        private void OnTransactionInitiated(BaseTransaction transaction)
        {
            if (m_WaitAnimation == null && waitAnimationPrefab != null)
            {
                m_WaitAnimation = Instantiate(waitAnimationPrefab).transform;
            }
        }

        /// <summary>
        ///     Callback that gets triggered when any item in the store is successfully purchased. Triggers the
        ///     user-specified onPurchaseSuccess callback.
        /// </summary>
        private void OnTransactionSucceeded(BaseTransaction transaction, TransactionResult result)
        {
            RemoveLoadingAnimation();
        }

        /// <summary>
        ///     Callback that gets triggered when any item in the store is attempted and fails to be purchased. Triggers the
        ///     user-specified onPurchaseFailure callback.
        /// </summary>
        private void OnTransactionFailed(BaseTransaction transaction, Exception exception)
        {
            RemoveLoadingAnimation();
        }

        /// <summary>
        ///     Removes wait animation from scene and the reference of its transform.
        /// </summary>
        private void RemoveLoadingAnimation()
        {
            if (m_WaitAnimation == null) return;
            Destroy(m_WaitAnimation.gameObject);
            m_WaitAnimation = null;
        }
    }
}
