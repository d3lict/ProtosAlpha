'use client';

import { useEffect, useState } from 'react';
import { useRouter } from 'next/navigation';

export default function DashboardPage() {
  const router = useRouter();
  const [user, setUser] = useState<any>(null);

  useEffect(() => {
    const token = localStorage.getItem('token');
    if (!token) {
      router.push('/login');
      return;
    }

    // Decode token or fetch user info, for now assume user from token
    // For simplicity, set dummy user
    setUser({ login: 'admin', email: 'admin@example.com' });
  }, [router]);

  const handleLogout = () => {
    localStorage.removeItem('token');
    router.push('/login');
  };

  if (!user) return <div>Loading...</div>;

  return (
    <div className="wrapper">
      {/* Sidebar */}
      <aside className="sidebar bg-body-tertiary border-end">
        <div className="d-flex flex-column h-100">
          <div className="d-flex align-items-center justify-content-between p-3 border-bottom">
            <span className="fs-5 fw-semibold text-primary">ProtosAlpha</span>
            <button type="button" className="btn btn-link text-body d-lg-none p-0" data-dismiss="sidebar" aria-label="Close sidebar">
              <i className="bi bi-x-lg"></i>
            </button>
          </div>
          <nav className="sidebar-nav flex-grow-1 p-3">
            <ul className="nav flex-column gap-1">
              <li className="nav-item">
                <a className="nav-link active" href="/dashboard">
                  <i className="bi bi-grid-1x2-fill"></i>
                  <span>Dashboard</span>
                </a>
              </li>
              <li className="nav-item">
                <button className="nav-link btn btn-link text-start p-0" onClick={() => alert('Create Project')}>
                  <i className="bi bi-plus-circle"></i>
                  <span>Create a project</span>
                </button>
              </li>
              <li className="nav-item">
                <button className="nav-link btn btn-link text-start p-0" onClick={() => alert('Create Test Plan')}>
                  <i className="bi bi-clipboard-check"></i>
                  <span>Create a test plan</span>
                </button>
              </li>
              <li className="nav-item">
                <button className="nav-link btn btn-link text-start p-0" onClick={() => alert('Create Test Cases')}>
                  <i className="bi bi-file-earmark-plus"></i>
                  <span>Create test cases</span>
                </button>
              </li>
              <li className="nav-item">
                <button className="nav-link btn btn-link text-start p-0" onClick={() => alert('Assign Test Cases')}>
                  <i className="bi bi-person-plus"></i>
                  <span>Assign test cases</span>
                </button>
              </li>
              <li className="nav-item">
                <button className="nav-link btn btn-link text-start p-0" onClick={() => alert('Manage Projects')}>
                  <i className="bi bi-folder"></i>
                  <span>Manage projects</span>
                </button>
              </li>
              <li className="nav-item">
                <button className="nav-link btn btn-link text-start p-0" onClick={() => alert('Manage Test Plans')}>
                  <i className="bi bi-clipboard-data"></i>
                  <span>Manage test plans</span>
                </button>
              </li>
              <li className="nav-item">
                <button className="nav-link btn btn-link text-start p-0" onClick={() => alert('Manage Users')}>
                  <i className="bi bi-people"></i>
                  <span>Manage users</span>
                </button>
              </li>
            </ul>
          </nav>
          <div className="p-3 border-top">
            <div className="d-flex align-items-center gap-3">
              <div className="rounded-circle bg-primary text-white d-flex align-items-center justify-content-center" style={{ width: '40px', height: '40px' }}>
                <i className="bi bi-person-fill"></i>
              </div>
              <div className="flex-grow-1 min-w-0">
                <div className="fw-medium text-truncate">{user.login}</div>
                <div className="small text-body-secondary text-truncate">{user.email}</div>
              </div>
            </div>
          </div>
        </div>
      </aside>

      {/* Main Content */}
      <div className="main-content">
        <header className="sticky-top bg-body border-bottom">
          <div className="d-flex align-items-center justify-content-between px-3 px-lg-4 py-2">
            <button type="button" className="btn btn-link text-body d-lg-none p-0 me-3" data-toggle="sidebar" aria-label="Toggle sidebar">
              <i className="bi bi-list fs-4"></i>
            </button>
            <div className="flex-grow-1 me-3" style={{ maxWidth: '400px' }}>
              <div className="input-group">
                <span className="input-group-text bg-transparent border-end-0"><i className="bi bi-search"></i></span>
                <input type="search" className="form-control border-start-0" placeholder="Search projects, test cases..." />
              </div>
            </div>
            <div className="d-flex align-items-center gap-2">
              <button type="button" className="btn btn-link text-body p-2" onClick={handleLogout}>
                <i className="bi bi-box-arrow-right"></i>
              </button>
            </div>
          </div>
        </header>

        <main className="p-3 p-lg-4">
          <div className="d-flex flex-wrap align-items-center justify-content-between gap-3 mb-4">
            <div>
              <h1 className="h3 mb-1">Test Management Dashboard</h1>
              <nav aria-label="breadcrumb">
                <ol className="breadcrumb mb-0">
                  <li className="breadcrumb-item active" aria-current="page">Dashboard</li>
                </ol>
              </nav>
            </div>
          </div>

          {/* Stats */}
          <div className="row g-3 mb-4">
            <div className="col-sm-6 col-xl-3">
              <div className="card h-100">
                <div className="card-body">
                  <div className="d-flex align-items-start justify-content-between">
                    <div>
                      <div className="text-body-secondary small mb-1">Active Projects</div>
                      <div className="h4 mb-0">5</div>
                    </div>
                    <div className="rounded bg-primary bg-opacity-10 p-2">
                      <i className="bi bi-folder fs-4 text-primary"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div className="col-sm-6 col-xl-3">
              <div className="card h-100">
                <div className="card-body">
                  <div className="d-flex align-items-start justify-content-between">
                    <div>
                      <div className="text-body-secondary small mb-1">Test Cases</div>
                      <div className="h4 mb-0">120</div>
                    </div>
                    <div className="rounded bg-success bg-opacity-10 p-2">
                      <i className="bi bi-file-earmark-check fs-4 text-success"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div className="col-sm-6 col-xl-3">
              <div className="card h-100">
                <div className="card-body">
                  <div className="d-flex align-items-start justify-content-between">
                    <div>
                      <div className="text-body-secondary small mb-1">Executions</div>
                      <div className="h4 mb-0">89</div>
                    </div>
                    <div className="rounded bg-warning bg-opacity-10 p-2">
                      <i className="bi bi-play-circle fs-4 text-warning"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div className="col-sm-6 col-xl-3">
              <div className="card h-100">
                <div className="card-body">
                  <div className="d-flex align-items-start justify-content-between">
                    <div>
                      <div className="text-body-secondary small mb-1">Users</div>
                      <div className="h4 mb-0">12</div>
                    </div>
                    <div className="rounded bg-info bg-opacity-10 p-2">
                      <i className="bi bi-people fs-4 text-info"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div className="text-center">
            <p>Welcome to ProtosAlpha Test Management System</p>
          </div>
        </main>
      </div>
    </div>
  );
}