using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestLinkBackend.Models
{
    public class NodeHierarchy
    {
        [Key]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int NodeType { get; set; }
        [Required]
        public string Name { get; set; }
        public int TestprojectId { get; set; }
    }

    public class Testproject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Prefix { get; set; }
        public string ApiKey { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }

    public class Testcase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int TestprojectId { get; set; }
    }

    public class TestcaseVersion
    {
        [Key]
        public int Id { get; set; }
        public int TestcaseId { get; set; }
        public int Version { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }

    public class Requirement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int TestprojectId { get; set; }
    }

    public class RequirementVersion
    {
        [Key]
        public int Id { get; set; }
        public int RequirementId { get; set; }
        public int Version { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }

    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Locale { get; set; }
        public int? DefaultTestprojectId { get; set; }
        public bool Active { get; set; }
    }

    public class Attachment
    {
        [Key]
        public int Id { get; set; }
        public int FkId { get; set; }
        [Required]
        public string FkTable { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public byte[] FileContent { get; set; }
        public DateTime CreationTs { get; set; }
        public int? AuthorId { get; set; }
    }

    public class Keyword
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Notes { get; set; }
        public int TestprojectId { get; set; }
    }

    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string LogLevel { get; set; }
        [Required]
        public string Description { get; set; }
        public int? UserId { get; set; }
        public int? ObjectId { get; set; }
        public string ObjectType { get; set; }
        public int? TransactionId { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public int TestprojectId { get; set; }
        public DateTime CreationTs { get; set; }
    }

    public class SearchResult
    {
        public IEnumerable<Testcase> TestCases { get; set; }
        public IEnumerable<TestSuite> TestSuites { get; set; }
        public IEnumerable<Requirement> Requirements { get; set; }
        public IEnumerable<RequirementSpec> RequirementSpecs { get; set; }
    }

    public class UserRole
    {
        [Key]
        public int UserId { get; set; }
        public int TestprojectId { get; set; }
        public int RoleId { get; set; }
    }

    public class Testplan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int TestprojectId { get; set; }
    }

    public class TestplanRole
    {
        [Key]
        public int UserId { get; set; }
        public int TestplanId { get; set; }
        public int RoleId { get; set; }
    }

    public class Execution
    {
        [Key]
        public int Id { get; set; }
        public int TestplanId { get; set; }
        public int TestcaseVersionId { get; set; }
        public int BuildId { get; set; }
        public int PlatformId { get; set; }
        public DateTime ExecutionTs { get; set; }
        public bool Status { get; set; }
    }

    public class Build
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int TestprojectId { get; set; }
    }

    public class Platform
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int TestprojectId { get; set; }
    }

    public class TestCasePlatform
    {
        [Key]
        public int TestcaseId { get; set; }
        public int TestcaseVersionId { get; set; }
        public int PlatformId { get; set; }
    }

    public class TestCaseRelation
    {
        [Key]
        public int Id { get; set; }
        public int SourceId { get; set; }
        public int DestinationId { get; set; }
        public int RelationType { get; set; }
        public bool Status { get; set; }
    }

    public class RequirementRelation
    {
        [Key]
        public int Id { get; set; }
        public int SourceId { get; set; }
        public int DestinationId { get; set; }
        public int RelationType { get; set; }
        public bool Status { get; set; }
    }

    public class RequirementMonitor
    {
        [Key]
        public int RequirementId { get; set; }
        public int UserId { get; set; }
        public int TestprojectId { get; set; }
    }

    public class TextTemplate
    {
        [Key]
        public int Id { get; set; }
        public int Type { get; set; }
        [Required]
        public string Title { get; set; }
        public string TemplateData { get; set; }
        public int? AuthorId { get; set; }
        public DateTime CreationTs { get; set; }
        public bool IsPublic { get; set; }
    }

    public class Plugin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Basename { get; set; }
        public bool Enabled { get; set; }
        public int? AuthorId { get; set; }
        public DateTime CreationTs { get; set; }
    }

    public class PluginConfiguration
    {
        [Key]
        public int Id { get; set; }
        public int TestprojectId { get; set; }
        [Required]
        public string ConfigKey { get; set; }
        public int ConfigType { get; set; }
        public string ConfigValue { get; set; }
        public int? AuthorId { get; set; }
        public DateTime CreationTs { get; set; }
    }

    public class IssueTracker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Type { get; set; }
        public string Config { get; set; }
    }

    public class TestprojectIssueTracker
    {
        [Key]
        public int TestprojectId { get; set; }
        public int IssueTrackerId { get; set; }
    }

    public class CodeTracker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Type { get; set; }
        public string Config { get; set; }
    }

    public class TestprojectCodeTracker
    {
        [Key]
        public int TestprojectId { get; set; }
        public int CodeTrackerId { get; set; }
    }

    public class RequirementManagerSystem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Type { get; set; }
        public string Config { get; set; }
    }

    public class TestprojectRequirementManagerSystem
    {
        [Key]
        public int TestprojectId { get; set; }
        public int RequirementManagerSystemId { get; set; }
    }

    public class RequirementSpec
    {
        [Key]
        public int Id { get; set; }
        public int TestprojectId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalRequirement { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
    }

    public class RequirementSpecRevision
    {
        [Key]
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int Revision { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalRequirement { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public string LogMessage { get; set; }
        public int? AuthorId { get; set; }
        public DateTime CreationTs { get; set; }
        public int? ModifierId { get; set; }
        public DateTime ModificationTs { get; set; }
    }

    public class RequirementRevision
    {
        [Key]
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int Revision { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public int Active { get; set; }
        public int IsOpen { get; set; }
        public int ExpectedCoverage { get; set; }
        public string LogMessage { get; set; }
        public int? AuthorId { get; set; }
        public DateTime CreationTs { get; set; }
        public int? ModifierId { get; set; }
        public DateTime ModificationTs { get; set; }
    }

    public class UserAssignment
    {
        [Key]
        public int Id { get; set; }
        public int Type { get; set; }
        public int FeatureId { get; set; }
        public int UserId { get; set; }
        public int BuildId { get; set; }
        public DateTime DeadlineTs { get; set; }
        public int AssignerId { get; set; }
        public DateTime CreationTs { get; set; }
        public int Status { get; set; }
    }

    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EntryPoint { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int UserId { get; set; }
        [Required]
        public string SessionId { get; set; }
    }

    public class UserGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class UserGroupAssign
    {
        [Key]
        public int UsergroupId { get; set; }
        public int UserId { get; set; }
    }

    public class ObjectKeyword
    {
        [Key]
        public int Id { get; set; }
        public int FkId { get; set; }
        [Required]
        public string FkTable { get; set; }
        public int KeywordId { get; set; }
    }

    public class TestCaseKeyword
    {
        [Key]
        public int Id { get; set; }
        public int TestcaseVersionId { get; set; }
        public int KeywordId { get; set; }
    }

    public class RequirementKeyword
    {
        [Key]
        public int Id { get; set; }
        public int RequirementVersionId { get; set; }
        public int KeywordId { get; set; }
    }

    public class TestSuite
    {
        [Key]
        public int Id { get; set; }
        public string Details { get; set; }
    }

    public class BaselineContext
    {
        [Key]
        public int Id { get; set; }
        public int TestplanId { get; set; }
        public int PlatformId { get; set; }
        public DateTime BeginExecTs { get; set; }
        public DateTime EndExecTs { get; set; }
        public DateTime CreationTs { get; set; }
    }

    public class BaselineDetail
    {
        [Key]
        public int Id { get; set; }
        public int ContextId { get; set; }
        public int TopTsuiteId { get; set; }
        public int ChildTsuiteId { get; set; }
        public string Status { get; set; }
        public int Qty { get; set; }
        public int TotalTc { get; set; }
    }

    public class TestLinkView
    {
        public int TestcaseId { get; set; }
        public int Version { get; set; }
        public int TcversionId { get; set; }
    }

    public class TestLinkView2
    {
        public int TestcaseId { get; set; }
        public int Version { get; set; }
        public int TcversionId { get; set; }
    }

    public class TestLinkView3
    {
        public int ReqId { get; set; }
        public int Version { get; set; }
        public int ReqVersionId { get; set; }
    }

    public class TestLinkView4
    {
        public int ReqSpecId { get; set; }
        public int TestprojectId { get; set; }
        public int Revision { get; set; }
    }

    public class TestLinkView5
    {
        public int TestcaseId { get; set; }
        public int TcversionId { get; set; }
    }

    public class TestLinkView6
    {
        public int TestcaseId { get; set; }
        public int TcversionId { get; set; }
    }

    public class TestLinkView7
    {
        public int TestcaseId { get; set; }
        public int TcversionId { get; set; }
    }

    public class TestLinkView8
    {
        public string Prefix { get; set; }
        public string TestprojectName { get; set; }
        public string Level1Name { get; set; }
        public string Level2Name { get; set; }
        public int TestprojectId { get; set; }
        public int Level1Id { get; set; }
        public int Level2Id { get; set; }
    }

    public class TestLinkView9
    {
        public string TestplanName { get; set; }
        public string YyyyMmDd { get; set; }
        public string YyyyMm { get; set; }
        public string Hh { get; set; }
        public string Hour { get; set; }
        public int Id { get; set; }
        public int TestplanId { get; set; }
        public int TestcaseVersionId { get; set; }
        public int BuildId { get; set; }
        public int PlatformId { get; set; }
        public DateTime ExecutionTs { get; set; }
        public bool Status { get; set; }
    }

    // Additional models for JWT
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class AuthResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public User User { get; set; }
    }
}
