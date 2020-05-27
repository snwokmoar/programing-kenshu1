#include<iostream>
#include<cmath>
#include<ctime>
#include<vector>
#include<random>

int N = 500;
int N2 = 2*N;
int mmiss = 0;
int smiss = 0;

std::vector<double> M;

void makemoment(){
  std::random_device rnd;
  std::mt19937 mt(rnd());
  std::uniform_int_distribution<> rand10(0,99);
  M.resize(N2+1);
  for(int i=0;i<=N2;i++){
    M[i] = std::pow((double)rnd()/0xffffffff, 3.0);
    //std::cout << M[i] << std::endl;
  }
}
void makemoment2(){
  std::random_device rnd;
  M.resize(N2+1);
  for(int i=0;i<=N2;i++){
    M[i] = (double)rnd()/0xffffffff;
  }
}
void FG(){
  std::vector< std::vector<double> > F;
  std::vector< std::vector<double> > G;

  F.resize(N+1);
  G.resize(N+1);
  for(int i=0;i<=N;i++){
    F[i].resize(N2+1);
    G[i].resize(N2+1);
  }

  for(int j=0;j<=N2-2;j++){
    F[1][j] = 0;
    G[1][j] = -M[j+1]/M[j];
  }

  for(int i=1;i<=N-1;i++){
    for(int j=i-1;j<=N2-i-1;j++){
      F[i+1][j] = F[i][j+1] + G[i][j+1] - G[i][j];
    }
    for(int j=i;j<=N2-1;j++){
      G[i+1][j] = F[i+1][j]*G[i][j-1]/F[i+1][j-1];
    }
  }

  if(std::isnan(G[N][N-1])){
    ++mmiss;
  }


}

void LP(){

  std::vector< std::vector<double> > s;
  std::vector<double> u;
  std::vector<double> v;
  s.resize(N+1);
  u.resize(N+1);
  v.resize(N+1);
  for(int i=0;i<=N;i++){
    s[i].resize(N2+1);
  }

  for(int j=0;j<=N2-1;j++){
    s[0][j] = M[N2-j-1];
  }
  u[0] = -s[0][N-1]/s[0][N];
  v[0] = 0;

  for(int j=1;j<=N-1;j++){
    s[1][j] = s[0][j-1] + u[0]*s[0][j];
  }
  for(int j=N+1;j<=N2-1;j++){
    s[1][j] = s[0][j-1] + u[0]*s[0][j];
  }
  v[1] = s[1][N-1]/s[0][N-1];
  u[1] = v[1]*s[0][N]/s[1][N+1];

  for(int i=2;i<=N;i++){
    for(int j=i;j<=N-1;j++){
      s[i][j] = s[i-1][j-1] + u[i-1]*s[i-1][j] - v[i-1]*s[i-2][j-1];
    }
    for(int j=N+i;j<=N2-1;j++){
      s[i][j] = s[i-1][j-1] + u[i-1]*s[i-1][j] - v[i-1]*s[i-2][j-1];
    }
    v[i] = s[i][N-1]/s[i-1][N-1];
    u[i] = v[i]*s[i-1][N+i-1]/s[i][N+i];
  }
  if(std::isnan(u[N-1])){
    ++smiss;
  }
}

int main(){
  for(int i=0;i<10000;i++){
    //std::cout << i << ": ";
    makemoment();
    FG();
    LP();
  }
  std::cout << "FGmiss = " << mmiss << std::endl;
  std::cout << "LPmiss = " << smiss << std::endl;
}
