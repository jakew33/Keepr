import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},

  // This is for the homepage
  /** @type {import('./models/Keep.js').Keep[]} */
  keeps: [],
  // this is for the KeepModal
  activeKeep: null,

  // REVIEW YOU CAN FILL THESE OUT ANYTIME THE USER AUTHENTICATES
  /** @type {import('./models/Vault.js').Vault[]} */
  myVaults: [],
  /** @type {import('./models/Keep.js').Keep[]} */
  myKeeps: [],

  // SECTION for the Vault Page
  /** @type {import('./models/VaultKeep.js').VaultKeep} */
  activeVault: null,
  vaultKeeps: [],
  activeVaultKeep: null,

  // SECTION THESE ARE FOR THE PROFILE PAGE (AKA SOMEONE ELSE)
  /** @type {import('./models/Profile.js').Profile | null} */
  activeProfile: null,
  /** @type {import('./models/Vault.js').Vault[]} */
  activeProfileVaults: [],
  /** @type {import('./models/Keep.js').Keep[]} */
  activeProfileKeeps: [],
})
