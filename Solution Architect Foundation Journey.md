# Solution Architect Foundation Journey — Weekly Mastery Plan

> **Purpose:** A practical, adaptive learning journey for a .NET Software Engineer moving toward Solution Architect.
>
> **Planning model:** One week = one meaningful competency. Daily sessions are only the mechanism for learning the weekly competency.
>
> **Core rule:** Do not spend a full session teaching something that is already strong. Compress familiar material and spend the saved time on application, trade-offs, failure scenarios, and architecture decisions.
>
> **Duration:** 20 weeks
>
> **Weekly effort:** Designed for a working engineer. Do not overload a week. The goal is mastery of one capability, not completion of a long topic list.

---

## 1. Why This Plan Is Different

The previous journey was organized around individual topics and patterns. That made simple subjects capable of consuming an entire day and pushed architecture/application too far toward the end.

This plan changes the unit of progress:

```text
OLD

Day → Topic → Exercise


NEW

Week → Competency → Small set of concepts → Practice → Architecture judgment
```

The objective is not to memorize:

- SOLID definitions
- 23 GoF pattern names
- architecture buzzwords
- technology names

The objective is to become able to answer:

> **What problem do I have, what options do I have, what trade-off does each option create, and why would I choose one?**

---

# 2. Learner Context

This journey assumes the learner already has practical exposure to:

- C#
- .NET / ASP.NET Core
- Clean Architecture
- CQRS / MediatR
- MongoDB
- Redis
- RabbitMQ / MassTransit
- SignalR
- Docker
- Polly / resilience
- JWT / authorization
- Angular
- basic system-design concepts

Therefore, these subjects should **not automatically receive beginner-level treatment**.

The learning system must continuously distinguish between:

```text
UNKNOWN
    ↓
FAMILIAR
    ↓
UNDERSTANDS
    ↓
CAN IMPLEMENT
    ↓
CAN EXPLAIN
    ↓
CAN MAKE TRADE-OFF DECISIONS
```

The final stages matter most for the Solution Architect goal.

---

# 3. Weekly Learning Contract

Every week has exactly **one primary competency**.

A week may contain supporting concepts, but they exist only to support the weekly outcome.

### Every week must answer

1. What problem am I learning to solve?
2. What concepts are necessary?
3. What can I build or modify?
4. What architectural decision should I be able to make afterward?
5. What evidence shows that I actually learned it?

### Do NOT

- add extra topics just because they are related
- turn every named technology into a separate lesson
- spend a complete day defining a familiar concept
- introduce advanced enterprise patterns before the problem requires them
- teach all related concepts "just in case"

### Do

- keep the scope narrow
- use existing knowledge as a starting point
- increase difficulty when the learner demonstrates understanding
- use real C#/.NET examples
- connect concepts to real systems
- emphasize trade-offs
- revisit weak areas through spaced retrieval

---

# 4. Adaptive Difficulty Rule

Before teaching a topic, classify it:

### Level A — Strong

The learner can explain it and use it.

**Action:** 10–20 minute refresh at most, then move to an architecture problem.

### Level B — Familiar

The learner knows the idea but cannot confidently apply or defend it.

**Action:** Short explanation + implementation + decision exercise.

### Level C — Weak

The learner cannot explain or implement it reliably.

**Action:** Teach from first principles, then practice.

### Level D — Unknown

The concept is genuinely new.

**Action:** Teach the minimum foundation required, then apply it.

Never confuse **"I have heard of it"** with **"I understand it."**

---

# 5. Weekly Session Pattern

The scheduled task runs once per day, but the week is treated as one learning unit.

A normal week follows this rhythm:

### Session 1 — Understand

- Introduce the weekly problem.
- Establish the mental model.
- Identify only the concepts required.
- Test existing knowledge first.

### Session 2 — Build

- Implement a small example.
- Prefer C#/.NET.
- Keep the example deliberately small.

### Session 3 — Apply

- Modify or extend the example.
- Introduce one realistic complication.
- Observe what becomes difficult.

### Session 4 — Architecture Judgment

Compare 2–3 possible solutions.

For each solution ask:

- What does it simplify?
- What does it complicate?
- What does it cost?
- How does it fail?
- At what scale does it stop being appropriate?

### Session 5 — Real-World Connection

Connect the competency to:

- ASP.NET Core
- Clean Architecture
- CQRS/MediatR
- MongoDB
- Redis
- RabbitMQ/MassTransit
- SignalR
- Polly
- Docker
- existing professional code when appropriate

Do not force every technology into the lesson.

### Session 6 — Weekly Challenge

Give one realistic design/problem-solving task.

The learner must make decisions before seeing the reference solution.

### Session 7 — Retrieval + Weekly Review

No large new topic.

Review:

- what was learned
- what remains weak
- what decisions can now be made
- what was over-engineered
- what should be revisited later

Update the skills matrix.

---

# 6. Time Budget

The plan must respect the learner's working schedule.

### Working days

Target:

**60–120 minutes**

Do not intentionally fill the entire available time.

If the weekly objective is achieved early, stop or use the remaining time for optional practice.

### Non-working days

Target:

**2–4 hours**

Use additional time for:

- implementation
- architecture diagrams
- refactoring
- system-design exercises

Never add unrelated theory merely to consume available time.

---

# 7. The 20-Week Roadmap

## Week 1 — Object-Oriented Design

### Weekly outcome

> Given a small business requirement, design a clear object model with meaningful responsibilities and relationships.

### Learn

- Encapsulation as protection of invariants
- Abstraction
- Composition
- Inheritance
- Polymorphism
- Cohesion
- Coupling

### Keep it focused

Do not spend separate days memorizing definitions.

Use one domain and progressively improve it.

Suggested domain:

**Order / Payment / Shopping Cart**

### Practice

Start with a deliberately poor model and refactor it.

### Architect question

> How much behavior belongs inside an object, and when should responsibility move elsewhere?

### Evidence of mastery

The learner can explain why the chosen objects exist and why responsibilities are placed where they are.

---

# Week 2 — SOLID as Design Judgment

### Weekly outcome

> Identify design problems and improve them using SOLID without applying SOLID mechanically.

### Learn

- SRP
- OCP
- LSP
- ISP
- DIP

### Important constraint

Do not spend five days teaching five definitions.

Treat SOLID as a connected design system.

### Practice

Refactor one intentionally bad C# module.

### Architect question

> When does an abstraction improve a design, and when does it merely add indirection?

### Evidence

The learner can explain which principle is relevant **and why**, rather than simply naming a principle.

---

# Week 3 — Refactoring & Design Smells

### Weekly outcome

> Look at existing code and identify what should actually be changed.

### Learn

Only the most useful smells:

- God class
- Long method
- High coupling
- Low cohesion
- Primitive obsession
- Shotgun surgery
- Feature envy

### Practice

Take one realistic class and improve it incrementally.

### Architect question

> Is this code actually bad, or is it simply different from my preferred style?

### Evidence

The learner can justify a refactoring and identify when leaving the code alone is better.

---

# Week 4 — GoF Patterns: Creational + Structural

### Weekly outcome

> Recognize common object-creation and structural problems and choose a suitable solution.

### Patterns

Cover only the patterns that provide meaningful value:

- Factory Method
- Abstract Factory
- Builder
- Prototype
- Adapter
- Decorator
- Facade
- Proxy
- Composite

Briefly recognize:

- Singleton
- Bridge
- Flyweight

### Rule

Do not create one day per pattern.

Group patterns by the problem they solve.

### Practice

Build a small example where multiple patterns are possible and compare them.

### Architect question

> Which pattern reduces complexity here, and which pattern would only add complexity?

---

# Week 5 — GoF Patterns: Behavioral

### Weekly outcome

> Understand how behavior can be organized without creating rigid dependencies.

### Patterns

Focus on:

- Strategy
- Observer
- Command
- Mediator
- Chain of Responsibility
- State
- Template Method

Recognize:

- Iterator
- Visitor
- Memento
- Interpreter

### Real-world connections

- Strategy → OCP
- Command/Mediator → application workflows
- Chain of Responsibility → ASP.NET Core / pipeline behaviors
- Observer → event notification
- State → lifecycle-driven behavior

### Architect question

> Is the pattern solving a real variation problem, or am I creating abstractions before variation exists?

---

# Week 6 — Clean Architecture & Application Structure

### Weekly outcome

> Design a maintainable .NET application and explain why its boundaries exist.

### Learn

- Dependency direction
- Domain
- Application
- Infrastructure
- Presentation
- Dependency inversion
- CQRS
- Vertical Slice
- Modular boundaries

### Practice

Take a small feature and design its boundaries.

### Architect question

> Which boundary protects us from change?

### Important

Do not treat Clean Architecture as a fixed folder structure.

---

# Week 7 — API Architecture

### Weekly outcome

> Design a production-quality API around clear contracts and failure behavior.

### Learn

- Resource modeling
- REST fundamentals
- Validation
- Error handling
- Pagination
- Idempotency
- API versioning
- Rate limiting

### Practice

Design one API end-to-end.

### Architect question

> What should the API guarantee to its clients?

---

# Week 8 — Data Architecture

### Weekly outcome

> Choose a data model based on access patterns and consistency requirements.

### Learn

- SQL vs NoSQL
- Document modeling
- Indexes
- Transactions
- Consistency
- Read/write patterns
- Replication basics

### Practice

Model the same requirement in relational and document form.

### Architect question

> What query pattern and consistency requirement are driving my database choice?

---

# Week 9 — Caching with Redis

### Weekly outcome

> Introduce caching deliberately rather than automatically.

### Learn

- Cache-aside
- TTL
- Invalidation
- Hot data
- Cache stampede
- Distributed cache
- Redis basics

### Practice

Add caching to an API and analyze the failure cases.

### Architect question

> What happens when the cache is wrong or unavailable?

---

# Week 10 — Messaging & RabbitMQ

### Weekly outcome

> Design reliable asynchronous communication.

### Learn

- Queue
- Exchange
- Routing
- Consumer
- Competing consumers
- Retry
- Dead-letter queue
- Ordering
- Idempotent consumer

### Practice

Build a small order → payment workflow.

### Architect question

> Why should this interaction be asynchronous?

---

# Week 11 — Event-Driven Architecture

### Weekly outcome

> Understand when events are useful and what eventual consistency costs.

### Learn

- Commands vs events
- Domain events
- Integration events
- Eventual consistency
- Outbox pattern
- Event versioning

### Practice

Convert part of a synchronous workflow into an event-driven workflow.

### Architect question

> What new complexity did asynchronous communication introduce?

---

# Week 12 — Distributed Systems Fundamentals

### Weekly outcome

> Reason about systems where components communicate over unreliable networks.

### Learn

- Partial failure
- Network latency
- Timeout
- Retry
- Idempotency
- Consistency
- Availability
- CAP at a practical level

### Practice

Analyze failure scenarios for a distributed order system.

### Architect question

> What happens when the other service never responds?

---

# Week 13 — Resilience

### Weekly outcome

> Design a service that behaves predictably when dependencies fail.

### Learn

- Timeout
- Retry
- Circuit breaker
- Bulkhead
- Rate limiting
- Graceful degradation
- Polly

### Practice

Apply resilience policies to an external API.

### Architect question

> Can retry make the problem worse?

---

# Week 14 — Scalability

### Weekly outcome

> Explain how a system should evolve when traffic grows.

### Learn

- Vertical scaling
- Horizontal scaling
- Stateless services
- Load balancing
- Database bottlenecks
- Read replicas
- Partitioning basics
- CDN

### Practice

Take a system serving 1,000 users and reason about 1 million.

### Architect question

> What becomes the bottleneck first?

---

# Week 15 — Kubernetes & Container Orchestration

### Weekly outcome

> Deploy, expose, configure, scale, and update a containerized .NET application in Kubernetes, and understand when Kubernetes is justified.

### Learn

- Kubernetes mental model
- Cluster, node, pod
- Deployment
- Service
- ConfigMap
- Secret
- Ingress
- Health probes
- Resource requests and limits
- Horizontal Pod Autoscaler
- Rolling deployments
- Basic Kubernetes networking
- Kubernetes vs simpler deployment options

### Practice

Take a small ASP.NET Core application and reason through its deployment:

```text
.NET Application
      ↓
Docker Image
      ↓
Kubernetes Deployment
      ↓
Pods
      ↓
Service
      ↓
Ingress
      ↓
Users
```

Then introduce configuration, secrets, health checks, resource limits, multiple replicas, and a rolling update.

### Architect question

> Do we actually need Kubernetes for this system, and what problem would Kubernetes solve for us?

### Important constraint

Do not turn this into a Kubernetes administration course. The goal is architectural understanding plus enough hands-on knowledge to confidently read, design, and discuss a Kubernetes deployment.

---

# Week 16 — Security Architecture

### Learn

- Authentication
- Authorization
- JWT
- OAuth/OIDC concepts
- Secrets
- Encryption
- Common API security risks
- Threat modeling basics

### Practice

Threat-model one API.

### Architect question

> What are we protecting, from whom, and where is the trust boundary?

---

# Week 17 — Observability

### Weekly outcome

> Diagnose a production problem using system evidence.

### Learn

- Logs
- Metrics
- Traces
- Correlation IDs
- Health checks
- OpenTelemetry concepts
- Alerting

### Practice

Design observability for a distributed workflow.

### Architect question

> If this request fails in production, how will we find out why?

---

# Week 18 — System Design

### Weekly outcome

> Turn ambiguous requirements into a defensible architecture.

### Learn

A repeatable process:

```text
Requirements
    ↓
Constraints
    ↓
Capacity assumptions
    ↓
High-level components
    ↓
Data model
    ↓
Communication
    ↓
Failure handling
    ↓
Scaling
    ↓
Security
    ↓
Observability
    ↓
Trade-offs
```

### Practice

One complete system-design problem.

Possible systems:

- URL shortener
- Notification system
- Chat system
- Payment system

Do not attempt all of them in one week.

---

# Week 19 — Architecture Trade-offs

### Weekly outcome

> Defend an architecture decision instead of searching for a "best" architecture.

### Compare

- Monolith vs microservices
- SQL vs NoSQL
- REST vs messaging
- Sync vs async
- Cache vs database
- CQRS vs CRUD
- RabbitMQ vs direct HTTP

### Practice

For each decision:

```text
Option A
Advantages
Disadvantages
When appropriate

Option B
Advantages
Disadvantages
When appropriate

Decision
Why?
```

### Architect question

> What constraint makes one option better than another?

---

# Week 19 — Architecture Trade-offs & Real Codebase Review

### Weekly outcome

> Read an existing .NET codebase from an architectural perspective.

### Analyze

- Boundaries
- Dependencies
- Coupling
- Cohesion
- Patterns
- Data flow
- Messaging
- Resilience
- Security
- Observability
- Deployment concerns

### Practice

Create an architecture review.

### Important

Do not assume every unusual implementation is wrong.

Ask:

> What problem might this design have been solving?

---

# Week 20 — Capstone: Design and Defend

### Weekly outcome

> Design a complete system and defend the decisions.

Use a system close to the learner's experience, such as:

**School Management Platform**

### Cover

- Requirements
- Domain model
- API
- Application architecture
- Database
- Cache
- Messaging
- Authentication/authorization
- Resilience
- Observability
- Scaling
- Deployment
- Trade-offs

### Final test

The learner must be able to answer:

> Why did you choose this?

> What alternative did you reject?

> What happens when this component fails?

> What happens at 10× traffic?

> What would you change at 100× traffic?

> Where is this architecture over-engineered?

---

# 8. Weekly Review Format

At the end of every week, record:

```text
## Weekly Review

Week:
Competency:

### What I can now explain

-

### What I can now implement

-

### Architecture decisions I can make

-

### Weak areas

-

### Biggest mistake I made

-

### One trade-off I understand better

-

### Confidence

Weak / OK / Strong

### Should this topic return later?

Yes / No

If yes, why?
```

---

# 9. Skills Matrix

Maintain a matrix with these major competencies:

| Competency | Confidence |
|---|---|
| Object-Oriented Design | |
| SOLID | |
| Refactoring | |
| Design Patterns | |
| Clean Architecture | |
| API Architecture | |
| Data Architecture | |
| Caching | |
| Messaging | |
| Event-Driven Architecture | |
| Distributed Systems | |
| Resilience | |
| Scalability | |
| Kubernetes & Container Orchestration | |
| Security Architecture | |
| Observability | |
| System Design | |
| Architecture Trade-offs | |
| Codebase Architecture Review | |

Use:

- **Weak** — cannot explain/apply reliably
- **OK** — can apply with some help
- **Strong** — can explain, implement, and defend decisions

---

# 10. Rules for the Daily Scheduled Task

The scheduled task must:

1. Read the current weekly goal before starting.
2. Read the previous session and weekly review.
3. Determine what has already been understood.
4. Never restart from beginner explanations unnecessarily.
5. Stay inside the current week's competency.
6. Introduce the minimum concepts required.
7. Prefer implementation and decision-making over passive reading.
8. Use C#/.NET whenever code is useful.
9. Use realistic engineering problems.
10. Ask "why?" before "how?"
11. Include trade-offs.
12. Include failure scenarios when relevant.
13. Never introduce unrelated advanced topics merely because they are interesting.
14. If the weekly competency is already strong, increase difficulty instead of repeating theory.
15. If the learner is struggling, reduce scope rather than adding more explanation.
16. Do not force completion of a topic list.
17. At the end of the week, update the skills matrix.
18. Carry weak concepts forward into later review sessions.
19. Do not create artificial work just to fill the scheduled time.
20. The goal is **mastery, not daily content volume**.

---

# 11. The Architect Thinking Loop

Use this loop repeatedly throughout the journey:

```text
Problem
   ↓
Constraints
   ↓
Possible solutions
   ↓
Trade-offs
   ↓
Decision
   ↓
Implementation
   ↓
Failure scenarios
   ↓
Scale
   ↓
Re-evaluate
```

The most important step is not the pattern or technology.

It is:

> **Decision → Why?**

---

# 12. Final Goal

At the end of this journey, the learner should not simply be able to say:

> "This is the Strategy Pattern."

He should be able to say:

> "We have several algorithms that vary independently, so Strategy reduces conditional logic and lets us add new behavior without modifying the core workflow. The cost is another abstraction and more objects. For only two stable variations, I would probably keep it simple."

That is the level of reasoning this journey is designed to develop.

The final goal is:

```text
Developer
   ↓
Strong Engineer
   ↓
Design Thinker
   ↓
Architecture Decision Maker
   ↓
Solution Architect
```

**Core principle:**

> **Learn less at one time. Understand it deeply. Apply it. Defend the decision. Then move on.**
