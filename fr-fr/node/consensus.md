# Consensus

## 1 - Liste des termes

* **Proof of Stake** `PoS` - Un type d'algorithme qui utilise le consensus du réseau pour gérer la tolérance à l'erreur.

* **Proof of Work** `PoW` - Un type d'algorithme qui utilise la puissance de calcul pour gérer la tolérance à l'erreur.

* **Byzantine Fault** `BF` - Un échec dans lequel un noeud reste fonctionnel mais opère de mannière malhonnête.

* **delegated Byzantine Fault Tolerance** `dBFT` - Un algorithme de consensus implémenté dans la blockchain NEO pour garantir la tolérance à l'erreur.

* **Vue** `v` - Ensemble de données utilisé durant une activité de consensus dans NEO `DBFT`

## 2 - Roles
**Dans l'algoritme du consensus de NEO, les noeuds de consensus sont élu par les détenteurs de NEO et vote la validité des transactions. Ces noeuds sont également nommés "Bookkeepers". Dans les lignes suivantes, ces noeuds seront désignés comme "Noeuds de Consensus".**

  - <img style="vertical-align: middle" src="/assets/nNode.png" width="25"> **Noeuds de Consensus** - Ces noeuds participent aux activités de consensus. Pendant une activité de consensus, les noeuds de consensus vont assumer les deux rôles suivant tour à tour :
  - <img style="vertical-align: middle" src="/assets/speakerNode.png" width="25"> **Orateur** `(Un)` - L'**Orateur** est responsable de la transmission d'une proposition de bloc dans le système.
  - <img style="vertical-align: middle" src="/assets/cNode.png" width="25"> **Délégué** `(Multiples)` - Les **Délégués** ont la responsabilité d'aboutir à un consensus sur la transaction.
  
## 3 - Introduction

Une des différences fondamentales entre les blockchains se caractérise par la façon dont elle garantisse une tolérance à l'erreur en cas d'activité défectueuse, c'est-à-dire en cas d'activité malhonnête du réseaux.

Les méthodes traditionnelles implémentées en utilisant le PoW peuvent fournir cette garantie aussi longtemps que la majorité de la puissance de calcul du réseau est honnête. Cependant, à cause de cette dépendance au calcul, le mécanisme peut être assez inefficace. En effet, la puissance de calcul coûte énormement d'énergie et à besoin de beaucoup de matériels informatiques. Ces dépendances expose le réseau PoW a un nombre de limitation, la première étant le coût de son évolution.

NEO implémente l'algorithme de consensus delegated Byzantine Fault Tolerance qui prend les avantages de quelques fonctionnalités similaires au PoS (les possesseurs de NEO vote pour des **noeuds de consensus**) et qui protège le réseau des problèmes de Byzance en utilisant un minimum de ressources tout en effaçant certain des problèmes du PoS. Cette solution aborde les problèmes de performance et d'évolutivité associés aux implémentation de blockchains actuelles sans un avoir un impact significatif quant à la tolérance à l'erreur.

## 4 - La théorie

Le problèmes des généraux généraux byzantins est un problème classique dans les calculs distribués. Le problème définit un nombre de **délégués** qui doivent tous trouver un consensus sur les résultats des ordres d'un **orateur**. Dans ce système, nous avons besoin d'être très prudent car l'**orateur** ou n'importe lequel des délégués peuvent être des traitres. Un noeud malhonnête peut en envoyer un envoyé un message considéré comme consistant à chacun des autres et cela est considéré comme la situation la plus désastreuse. La solution a ce problème demande que les **délégués** identifient en groupe si l'**orateur** est honnête et comment son commandement est considéré.

Dans le but de décrire comment le dBFT fonctionne, nous allons commencer par nous pencher sur la justification du taux de consensus à 66,66% utilisé dans la section 5. Il faut garder en mémoire qu'un noeuds malhonnête ne doit pas forcement être activement mal intentionné, il peut simplement ne pas fonctionner comme attendu.

Pour les besoins de la discussion, nous allons décrire différents scénario. Dans ces exemples simples, nous assumerons que chaque noeuds envoient le message qu'il a reçu de l'**orateur**. Ce mécanisme est utilisé dans le dBFT aussi et est critique dans le système. Nous allons seulement décrire la différence entre un système fonctionnel et un système non-fonctionnel. Pour plus d'informations, veuillez voir les références.

### **Un orateur honnête**

  <p align="center"><img src="/assets/n3.png" width="300"><br> <b>Figure 1:</b> Un exemple avec n = 3 et un <b>délégué</b> malhonnête.</p>
  
Dans la **figure 1**, nous avons seulement un seul **délégué** loyal (50%). Les deux **délégués** reçoive le même message d'un **orateur** honnête. Cependant, comme un des deux est malhonnête, celui qui est honnête peut seulement déterminer qu'il y a un noeud malhonnête mais il n'est pas dans la capacité de savoir si c'est le nucléateur du bloc (l'**orateur) ou le **délégué**. A cause de cela, ce **délégué** doit s'abstenir de vote, changeant la vue.

  <p align="center"><img src="/assets/n4.png" width="400"><br> <b>Figure 2:</b> Un exemple avec n = 4 et un <b>délégué</b> malhonnête.</p>

Dans la **figure 2**, nous avons deux **délégués** loyaux (66%). Tous les **délégués** reçoivent le même message d'un **orateur** honnête et envoient leur résultat de validité avec le message reçu de l'**orateur** aux autres **délégués**. Basé sur le consensus de deux honnêtes **délégués**, nous sommes capable de determiner qui de l'**orateur** ou du **délégué** est malhonnête dans le système.

### **Un orateur malhonnête**

  <p align="center"><img src="/assets/g3.png" width="300"><br> <b>Figure 3:</b> Un exemple avec n = 3 example et un <b>orateur</b> malhonnête. </p>
  
Dans le cas de la **figure 3** avec un **orateur**, nous avons une fin identique à la **figure 1**. Aucun des **délégués** n'est capable de déterminer quel noeud est malhonnête.

  <p align="center"><img src="/assets/g4.png" width="400"><br> <b>Figure 4:</b> Un exemple avec n = 4 et un <b>orateur</b> malhonnête. </p>

Dans l'exemple exposé par la **figure 4**, les blocs reçus par le noeud du milieu et celui à droite ne sont pas validable. Cela les incite à changer de vue et à élire un nouvel **orateur** parce qu'ils détiennent une majorité à 66%. Dans cet exemple, si l'**orateur** malhonnêteavait envoyé des données correctes à deux des trois **délégués**, cela aurait été validé sans le besoin de changer de vue.

## 5 - Implémentation pratique

L'implémentation pratique du dBFT dans NEO utilise une méthode de consensus itérative pour garantir le fait que le consensus est atteint. La performance de l'algorithme dépend de la fraction de noeuds honnêtes dans le système. La **figure 5** représente le nombre d'itérations attendues en fonction de la fraction de noeuds honnêtes.

Il faut savoir que la **figure 5** ne va pas en dessous de 66,66% de **noeuds de consensus** honnêtes. Entre ce point critique et 33,33% de **noeuds de consensus** honnêtes, il y a un "No-Man's Land" dans lequel un consensus est inatteignable. En dessous de 33,33% de **noeuds de consensus** honnêtes, les noeuds malhonnêtes (si seulement si ils s'alignent au même consensus) sont capable d'atteindre un consensus par eux-mêmes et deviennent la nouvelle vérité du système.

<img src="/assets/consensus.iterations.png" width="800">

**Figure 5 :** La méthode de simulation de Monte-Carlo du dBFT représente le nombre d'itération requis pour atteindre un consensus. {100 noeuds; 100,000 blocs simulés avec une séléction aléatoire de noeuds honnête}

### 5.1 - Définitions

**Dans l'algorithme, nous définissons les variables suivantes :**

- `t`: Le temps alloué à la génération d'un bloc, mesuré en secondes/
	- Actuellement: `t = 15 secondes`
		- Cette valeur peut être utilisée pour approximer grossièrement la durée de l'itération d'une vue tels que l'activité de consensus et les évènements de communication sont relativement aussi rapide que cette constante de temps.
			
	
- `n` : Le nombre de **noeuds de consensus** actifs.
	
	
- `f` : Le seuil minimum de **noeuds de consensus** fautifs dans le système.
	- `f = (n -1) / 3`
		
		
- `h` : La taille du bloc actuel pendant l'activité de consensus.
	
	
- `i` : L'index des **noeuds de consensus**
	
	
- `v` : La vue d'un **noeud de consensus**. Cette vue contient l'information agrégé que le noeud a reçu pendant un tour de consensus. Cela inclut le vote (`prepareResponse` ou `ChangeView`) publié par l'ensemble des **délégués**.
	
	
- `k` : L'index de la vue `v`. Une activité de consensus peut avoir besoin de plusieurs tours. En cas d'échec de consensus, `k` est incrémenté et un nouveau tour commence.
	
	
- `p` : L'index des **noeuds de consensus** élu comme **orateur**. Ce mécanisme de calcul pour cet index permet l'alternance des **noeuds de consensus** pour empêcher qu'un unique noeud commence à agir tel un dictateur dans le système.
	- `p = (h - k) mod (n)`
		
	
- `s` : Le seuil de sécurité du consensus. En dessous de ce seuil, le réseau est exposé à l'erreur.
	- `s = ((n - 1) - f)`
		
### 5.2 Prérequis

**Dans le système NEO, il existe trois prérequis pour avoir une tolérance à l'erreur du consensus :**

1. `s` **délégués** doivent atteindre un consensus sur une transaction avant qu'un bloc puis être réalisé.

2. Les **noeuds de consensus** malhonnêtes ne doivent pas être capable de convaincre les **noeuds de consenus** honnêtes de transactions fautives.

3. Au moins `s` **délégués** sont dans le même état (`h`, `k`) pour commencer une activité de consensus.

### 5.3 - L'algorithme

**L'algorithme fonctionne comme expliqué ci-dessous :**

1. Un **noeud de consensus** diffuse une transaction dans l'entièreté du réseau avec la signature de l'expéditeur.

  <p align="center"><img src="/assets/consensus1.png" width="450"><br> <b>Figure 6:</b> Un <b>noeud de consensus</b> reçoit une transaction et la diffuse dans tout le réseau.</p>
  
2. Les **noeuds de consensus** enregistre les données de la transaction dans la mémoire locale.

3. Le première vue `v` de l'activité de consensus est initialisé.

4. L'**orateur** est identifié.

  <p align="center"><img src="/assets/consensus2.png" width="450"><br> <b>Figure 7:</b> Un <b>orateur</b> a été identifié et la vue a été initialisée. </p>

  
**Attendre** `t` secondes
  
5. L'**orateur** diffuse la proposition :
  <!-- -->
    <prepareRequest, h, k, p, block, [block]sigp>
    
  <p align="center"><img src="/assets/consensus3.png" width="450"><br> <b>Figure 8:</b> L'<b>orateur</b> présente une proposition de bloc qui va être passée en revue par les <b>délégués</b>. </p>
		
6. Les **délégués** reçoivent la proposition et valident :

	- si le format des données coincide avec les règles du système;
	- si la transaction n'est pas déjà dans la blockchain;
	- si le script de contrat a été correctement éxécuté;
	- si la transaction ne contient qu'une seule dépense (par exemple, est-ce que la transaction évite un scénario de double-dépense).

  **Si la proposition est validée :**
  <!-- -->
    <prepareResponse, h, k, i, [block]sigi>
				
  **Si la proposition est refusée :**
  <!-- -->
    <ChangeView, h,k,i,k+1>
				
  <p align="center"><img src="/assets/consensus4.png" width="500"><br> <b>Figure 9:</b> Les <b>délégués</b> passe en revue la proposition et répondent. </p>
	
7. Après avoir reçu `s` nombre de messages broadcast "prepareResponse", un **délégué** atteint le consensus et décide de publier un bloc.

8. Les **délégués** signent le bloc.

   <p align="center"><img src="/assets/consensus5.png" width="500"><br> <b>Figure 10:</b> Un consensus est atteint et les <b>délégués</b> donnant leur approbation signent le bloc, l'accrochant à la chaîne. </p>
   
9. Quand un **noeud de consensus** reçoit un bloc complet, les données de la vue courrante sont purgés et un nouveau tour de consensus est commencé.
  - `k = 0`
		
---

**Note :**

Si après   (![timeout](/assets/consensus.timeout.png) )  secondes dans la même vue sans consensus :
  - Un **noeud de consensus** diffuse :
	
  <!-- -->
    <ChangeView, h,k,i,k+1>
				
  - Une fois qu'un **noeud de consensus** reçoit au moins `s` nombre de message broadcast indiquant un changement de vue, cela incrémente la vue `v`, enclenchant un nouveau tour de consensus.
	
## 6 - Références

1. [A Byzantine Fault Tolerance Algorithm for Blockchain](https://www.neo.org/Files/A8A0E2.pdf)
2. [Practical Byzantine Fault Tolerance](http://pmg.csail.mit.edu/papers/osdi99.pdf)
3. [The Byzantine Generals Problem](https://www.microsoft.com/en-us/research/wp-content/uploads/2016/12/The-Byzantine-Generals-Problem.pdf)
