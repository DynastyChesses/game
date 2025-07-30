# DynastyChesses

An innovative GameFi strategy game merging Chinese historical dynasties with chess-based warfare mechanics, built on the Internet Computer Protocol (ICP) blockchain.

## Project Overview

DynastyChesses combines the grandeur of Chinese historical dynasties with immersive strategic gameplay, leveraging blockchain technology and AI to create a unique GameFi experience. Players can build civilizations, command legendary generals, and engage in epic battles while exploring deep cultural narratives inspired by Chinese philosophy and history.

Key features include:
- 12 historically accurate Chinese dynasties with unique attributes
- 8 mythical races from Chinese folklore
- 120 legendary generals with distinct abilities
- Authentic battlefield maps based on historic Chinese battles
- ICP blockchain integration for transparent, decentralized gameplay
- Adaptive AI opponents that mimic historical strategies

## Installation & Deployment

### Prerequisites
- [DFX (ICP SDK)](https://sdk.dfinity.org/docs/quickstart/quickstart.html)
- Node.js (v16+)
- Git

### Local Development Setup

1. Clone the repository
   ```bash
   git clone https://github.com/your-username/dynastychesses.git
   cd dynastychesses
   ```

2. Install dependencies
   ```bash
   npm install
   ```

3. Start the local ICP replica
   ```bash
   dfx start --background
   ```

4. Deploy the canisters locally
   ```bash
   dfx deploy
   ```

5. Access the demo page
   After successful deployment, you'll see a URL in the output similar to:
   ```
   http://localhost:8000?canisterId=YOUR_LOCAL_CANISTER_ID
   ```
   Open this URL in your browser to view the demo.

### Deployment to ICP Mainnet

1. Ensure you have sufficient ICP tokens for cycle conversion

2. Deploy to the mainnet
   ```bash
   dfx deploy --network ic
   ```

3. Access the mainnet deployment
   The output will include your mainnet canister ID and URL, which will look like:
   ```
   https://YOUR_MAINNET_CANISTER_ID.ic0.app
   ```

## Project Structure

- `src/dynastychesses_assets/` - Frontend assets and demo page
- `images/` - Image assets for the demo
- `dfx.json` - ICP project configuration
- `deploy.sh` - Deployment automation script

## Technology Stack

- Frontend: HTML, TailwindCSS, JavaScript
- Blockchain: Internet Computer Protocol (ICP)
- Tools: DFX, Git

## Roadmap

- Phase 1: Core development of 12 dynasties and ICP integration
- Phase 2: Expansion with mythical races and NFT marketplace
- Phase 3: Global expansion with international civilizations and eSports integration

For more details, refer to the project documentation and demo page.
